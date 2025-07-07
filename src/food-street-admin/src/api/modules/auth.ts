import { createRequest } from "@frog/utils";
import type { LoginRequest, LoginResponseApi, ApiResponse } from "@/types";

export function login(data: LoginRequest): Promise<LoginResponseApi> {
  return createRequest({
    url: "/auth/login",
    method: "post",
    data,
  });
}

export function checkLogin(): Promise<ApiResponse> {
  return createRequest({
    url: "/auth/checkLogin",
    method: "get",
  });
}
