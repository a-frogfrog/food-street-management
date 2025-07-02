import { login, checkLogin } from "@/api";
import { ApiResponseCode, type LoginRequest, type UserInfo } from "@/types";
import { useToken } from "@frog/hooks";
import { defineStore } from "pinia";

/**
 * 鉴权模块
 */
export const useAuthStore = defineStore("auth", {
  state: () => ({
    token: useToken().getToken() || "",
    userInfo: {},
  }),
  getters: {
    isAuthenticated: (state) => (state.token ? true : false),
  },

  actions: {
    setToken(token: string) {
      this.token = token;
      useToken().setToken(token);
    },
    getToken(): string | undefined {
      return this.token;
    },
    setUserInfo(userInfo: UserInfo) {
      this.userInfo = userInfo;
    },

    async login(data: LoginRequest) {
      const response = await login(data);
      if (response.code === ApiResponseCode.Ok) {
        this.setToken(response.data.token);
      }
      return response;
    },

    async checkLogin() {
      const response = await checkLogin();
      if (response.code == ApiResponseCode.Ok) {
        this.setUserInfo(response.data);
      }

      return response;
    },
  },
});
