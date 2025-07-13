<script setup lang="ts">
import { TabBar } from '@frog/common-ui';
import type { TabBarProps } from '@frog/common-ui';
import { useTheme } from '@frog/hooks';
import { BasicLayout } from '@frog/layouts';
import { ref } from 'vue';

function useTabBar() {
  const activeName = ref('order');
  const item: TabBarProps = {
    items: [
      {
        name: 'order',
        icon: 'iconfont icon-dingdan',
        label: '订单',
      },
      {
        name: 'analysis',
        icon: 'iconfont icon-_shiyongcishu',
        label: '分析',
      },
      {
        name: 'product',
        icon: 'iconfont icon-shangpin',
        label: '商品',
      },
      {
        name: 'mine',
        icon: 'iconfont icon-wode',
        label: '我的',
        cover:
          'https://demos.themeselection.com/materio-vuetify-vuejs-admin-template/demo-1/images/avatars/avatar-1.png',
      },
    ],
  };

  function handleClick(name: string) {
    activeName.value = name;
  }

  return {
    activeName,
    item,
    handleClick,
  };
}

const { activeName, item, handleClick } = useTabBar();
const { currentTheme } = useTheme();
console.log(currentTheme);
</script>

<template>
  <BasicLayout>
    <template #tabbar>
      <TabBar
        v-model:active="activeName"
        :items="item.items"
        @tab-bar-item-click="handleClick"
      >
      </TabBar>
    </template>
  </BasicLayout>
</template>

<style scoped></style>
