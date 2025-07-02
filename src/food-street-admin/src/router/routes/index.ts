import type { RouteRecordRaw } from "vue-router";
import auth from "./modules/auth";
import dashboard from "./modules/dashboard";
import error from "./modules/error";
import product from "./modules/product";
import system from "./modules/system";

const routes: RouteRecordRaw[] = [
  {
    path: "/",
    component: () => import("@/layouts/basic.vue"),
    meta: {
      requiresAuth: true,
    },
    children: [
      dashboard, // 首页
      product, // 商品管理
      system, // 系统管理
    ],
  },
  auth, // 登录路由
  error, // 错误路由
];

export default routes;
