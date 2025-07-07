import type { ApiResponse } from "../shared/api";
import type { LoginResponse } from "./types";

export interface LoginResponseApi extends ApiResponse {
  data: LoginResponse;
}
