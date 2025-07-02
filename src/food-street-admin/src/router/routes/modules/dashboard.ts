const dashboard = {
  path: "",
  component: () => import("@/views/dashboard/index.vue"),
  meta: {
    requiresAuth: true,
  },
};

export default dashboard;
