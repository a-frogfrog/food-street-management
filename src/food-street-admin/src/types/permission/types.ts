import type { Component } from "vue";
import type { PermissionTypeItem } from "../shared/enums";

export interface PermissionItem {
  id: string; // 权限id
  name: string; // 权限名称
  url: string; // 权限url
  status: number; // 1:启用 2:禁用
  type: PermissionTypeItem; // 1:菜单 2:权限
  parentId: string; // 父级id
  icon: string; //图标icon
  serialNumber: number; // 排序
  description: string; // 描述
  time: string; // 创建时间
  children: PermissionItem[]; // 子权限
}

export interface PermissionMenuItem {
  id: string; // 权限id
  name: string; // 权限名称
  url: string; // 权限url
  parentId: string; // 父级id
  icon: string | Component; // 图标icon
  children: PermissionMenuItem[]; // 子菜单
}
