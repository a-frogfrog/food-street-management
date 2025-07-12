const mine = {
  path: '/mine',
  name: 'mine',
  component: () => import(/* webpackChunkName: "mine" */ '@/views/mine/index.vue'),
  meta: {
    title: '我的',
    keepAlive: true,
    icon: 'iconfont icon-wode',
    isShow: true,
  },
  children: [],
};

export default mine;