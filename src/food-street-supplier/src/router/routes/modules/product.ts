const product = {
  path: '/product',
  name: 'product',
  component: () => import('@/views/product/index.vue'),
  meta: {
    title: '产品管理',
    icon: 'product',
    permission: ['product'],
  }
};

export default product;