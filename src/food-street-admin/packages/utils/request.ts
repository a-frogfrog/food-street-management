import axios, {
  AxiosError,
  AxiosHeaders,
  type AxiosResponse,
  type InternalAxiosRequestConfig,
} from "axios";
import eventEmitter from "./eventEmitter";
import { useAuthStore } from "@/stores";
import { ApiResponseCode } from "@/types";

const instance = axios.create({
  baseURL: import.meta.env.VITE_API_BASE_URL,
  timeout: 20000,
  headers: {},
});

/**
 *  请求成功处理
 * @param response 响应
 * @returns  Promise
 */
const responseSuccessHandler = (response: AxiosResponse) => {
  eventEmitter.emit("progress:finish"); // 进度条结束
  if (response.data.code === ApiResponseCode.Ok) {
    response.data.isSucceed = true;
  }

  return Promise.resolve(response.data);
};

/**
 *  请求失败处理
 * @param error 错误
 * @returns Promise rejected
 */
const responseErrorHandler = (error: AxiosError) => {
  if (error.code === "ERR_NETWORK") {
    eventEmitter.emit("network:offline"); // 网络断开
  }
  if (error.status === 401) {
    eventEmitter.emit("api:unauthorized");
  }

  return Promise.reject(error);
};

/**
 *  请求拦截器
 * @param config 请求配置
 * @returns config object
 */
const requestHandler = (config: InternalAxiosRequestConfig) => {
  const authStore = useAuthStore();
  config.headers["Authorization"] = `Bearer ${authStore.getToken()}`;
  if (!config.headers) {
    config.headers = new AxiosHeaders();
  }
  eventEmitter.emit("progress:start"); // 进度条开始
  return config;
};

/**
 *  请求失败处理
 * @param error 错误
 * @returns  Promise rejected
 */
const requestErrorHandler = (error: AxiosError) => {
  return Promise.reject(error);
};

//使用响应拦截器
instance.interceptors.response.use(
  responseSuccessHandler,
  responseErrorHandler,
);

//使用请求拦截器
instance.interceptors.request.use(requestHandler, requestErrorHandler);

export default instance;
