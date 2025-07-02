import "vue-router";

declare module "vue-router" {
  interface RouteMeta {
    requiresAuth: boolean; // 是否需要登录
    icon?: string;
    title?: string;
  }
}
