import type { ApiResponseCode } from "./enums";

export interface ApiResponse<T = any> {
  code: ApiResponseCode;
  message: string;
  data: T;
  isSucceed: boolean;
}

export interface Pagisation {}
