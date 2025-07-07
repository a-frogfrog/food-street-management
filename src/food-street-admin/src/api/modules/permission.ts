import type { PermissionListApi, PermissionMenuApi } from "@/types";
import { createRequest } from "@frog/utils";

export function getPermissionList(): Promise<PermissionListApi> {
  return createRequest({
    url: "/Permission/GetPermissionList",
    method: "get",
    params: {},
  });
}

export function getPermissionMenu(): Promise<PermissionMenuApi> {
  return createRequest({
    url: "/Permission/GetUserPermissionMenuList",
    method: "get",
    params: {},
  });
}
