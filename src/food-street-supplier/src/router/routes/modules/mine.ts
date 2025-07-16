const mine = {
  path: '/mine',
  name: 'mine',
  component: () => import('@/views/mine/index.vue'),
  meta: {
    title: '我的',
    keepAlive: true,
    icon: 'iconfont icon-wode',
    isShow: true,
    tabBarPage: true,
  },
  children: [],
};

export default mine;
