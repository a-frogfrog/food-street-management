export interface LoginRequest {
  account: string;
  password: string;
}

export interface LoginResponse {
  token: string;
}
