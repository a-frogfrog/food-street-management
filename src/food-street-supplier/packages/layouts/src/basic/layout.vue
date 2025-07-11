<script setup lang="ts">
import { ref } from 'vue';
import { TabBar, TabBarItem } from '@frog/common-ui';
import type { TabBarItemProps } from '@frog/common-ui';
import LayoutContent from './content/content.vue';

defineOptions({ name: 'BasicLayout' });

const items: TabBarItemProps[] = [
  {
    name: 'home',
    icon: 'iconfont icon-shangpin',
    label: '首页',
  },
  {
    name: 'category',
    icon: 'iconfont icon-shangpin',
    label: '分类',
  },
  {
    name: 'cart',
    icon: 'iconfont icon-shangpin',
    label: '购物车',
  },
  {
    name: 'mine',
    icon: 'iconfont icon-shangpin',
    label: '我的',
  },
];

function handleClick(name: string) {
  console.log(name);
  activeName.value = name;
}

const activeName = ref('home');
</script>

<template>
  <div class="basic-layout">
    <LayoutContent></LayoutContent>
    <TabBar v-model="activeName">
      <TabBarItem
        v-for="item in items"
        :key="item.name"
        :name="item.name"
        :icon="item.icon"
        :label="item.label"
        @click="handleClick"
      ></TabBarItem>
    </TabBar>
  </div>
</template>

<style scoped>
.basic-layout {
  width: 100%;
  height: 100vh;
  background-color: #fffafa;
}
</style>
