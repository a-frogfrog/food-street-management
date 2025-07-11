import order from './order';

const routes = [
  {
    path: '/',
    name: 'root',
    component: () => import('@/layouts/basic.vue'),
    children: [
      order, // 订单
    ],
  },
];

export default routes;
