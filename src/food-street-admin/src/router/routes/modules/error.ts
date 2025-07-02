const error = {
  path: "/error",
  children: [
    {
      path: "network",
      name: "network",
      component: () => import("@/views/error/network/index.vue"),
    },
    {
      path: "/:pathMatch(.*)*",
      name: "notFound",
      component: () => import("@/views/error/not-found/index.vue"),
    },
  ],
};

export default error;
