const product = {
  path: "/product",
  name: "product",
  children: [
    {
      path: "list",
      name: "productList",
      component: () => import("@/views/product/list/index.vue"),
    },
    {
      path: "category",
      name: "productCategory",
      component: () => import("@/views/product/category/index.vue"),
    },
    {
      path: "add",
      name: "productAdd",
      component: () => import("@/views/product/add/index.vue"),
    },
  ],
};

export default product;
