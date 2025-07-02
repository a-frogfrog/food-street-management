const auth = {
  path: "/auth",
  name: "auth",
  children: [
    {
      path: "login",
      name: "login",
      component: () => import("@/views/auth/login/index.vue"),
    },
  ],
};

export default auth;
