import { PERMISSIONS } from "@frog/constants";

export enum ApiResponseCode {
  Ok = 0,
  Failed = -1,
  Unauthorized = 401,
  NotFound = 404,
  BadRequest = 400,
  Forbidden = 403,
  Error = 500,
}

export enum PermissionStatus {
  active = 1,
  banned = 0,
}

export enum PermissionType {
  menu = 1,
  page = 2,
}

export type PermissionTypeItem = (typeof PERMISSIONS)[keyof typeof PERMISSIONS];
