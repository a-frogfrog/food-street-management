const product = {
  path: '/product',
  name: 'product',
  component: () => import('@/views/product/index.vue'),
  meta: {
    tabBarPage: true,
  },
};

export default product;
