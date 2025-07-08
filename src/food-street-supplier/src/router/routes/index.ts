const routes = [
    {
        path: "/",
        name: "root",
        component: () => import("@/layouts/basic.vue"),
    },
];

export default routes;
