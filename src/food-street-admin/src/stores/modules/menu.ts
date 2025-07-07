import { defineStore } from "pinia";
import { type PermissionMenuItem } from "@/types";
import { getPermissionMenu } from "@/api";

/**
 * 菜单模块
 */
export const useMenuStore = defineStore("menu", {
  state: () => ({
    menuList: [] as PermissionMenuItem[], // 菜单列表
  }),
  getters: {
    getMenu(state) {
      return state.menuList;
    },
  },
  actions: {
    async getMenuList() {
      const response = await getPermissionMenu();
      if (response.isSucceed) {
        this.menuList = response.data;
      }
      return response;
    },

    clearMenuList() {
      this.menuList = [];
    },
  },
});
