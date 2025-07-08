import axios, {
    AxiosError,
    AxiosHeaders,
    type AxiosResponse,
    type InternalAxiosRequestConfig,
} from "axios";

const instance = axios.create({
    baseURL: import.meta.url,
    timeout: 20000,
    headers: {},
});

/**
 *  请求成功处理
 * @param response 响应
 * @returns  Promise
 */
const responseSuccessHandler = (response: AxiosResponse) => {
    return Promise.resolve(response.data);
};

/**
 *  请求失败处理
 * @param error 错误
 * @returns Promise rejected
 */
const responseErrorHandler = (error: AxiosError) => {
    return Promise.reject(error);
};

/**
 *  请求拦截器
 * @param config 请求配置
 * @returns config object
 */
const requestHandler = (config: InternalAxiosRequestConfig) => {
    if (!config.headers) {
        config.headers = new AxiosHeaders();
    }
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
    responseErrorHandler
);

//使用请求拦截器
instance.interceptors.request.use(requestHandler, requestErrorHandler);

export default instance;
