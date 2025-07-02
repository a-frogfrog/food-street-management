import type { ApiResponse } from "../shared/api";
import type { PermissionItem, PermissionMenuItem } from "./types";

export interface PermissionListApi extends ApiResponse {
  data: PermissionItem[]; // 权限列表
}

export interface PermissionMenuApi extends ApiResponse {
  data: PermissionMenuItem[]; // 菜单列表
}
