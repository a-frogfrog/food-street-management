const system = {
  path: "system",
  name: "system",
  children: [
    {
      path: "dictionary",
      name: "Dictionary",
      component: () => import("@/views/system/dictionary/index.vue"),
    },
    {
      path: "status",
      name: "Status",
      component: () => import("@/views/system/status/index.vue"),
    },
    {
      path: "icon",
      name: "Icon",
      component: () => import("@/views/system/icon/index.vue"),
    },
    {
      path: "permission",
      name: "Permission",
      component: () => import("@/views/system/permission/list/index.vue"),
    },
    {
      path: "permission/list",
      name: "PermissionList",
      component: () => import("@/views/system/permission/list/index.vue"),
    },
    {
      path: "permission/authorize",
      name: "PermissionAuthorize",
      component: () => import("@/views/system/permission/authorize/index.vue"),
    },
    {
      name: "loginLog",
      path: "log/login",
      component: () => import("@/views/system/log/login/index.vue"),
    },
    {
      name: "operationLog",
      path: "log/operation",
      component: () => import("@/views/system/log/operation/index.vue"),
    },
    {
      name: "errorLog",
      path: "log/error",
      component: () => import("@/views/system/log/error/index.vue"),
    },
  ],
};

export default system;
