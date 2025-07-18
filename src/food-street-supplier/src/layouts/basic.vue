<script setup lang="ts">
import { Page, Content, TabBar, ToolBar } from '@frog/common-ui';
import { ToolBarPopup } from '@/components';
import { useTabBar } from './tabbar';
import { useRoute } from 'vue-router';
import { ref, watchEffect } from 'vue';

defineOptions({ name: 'BasicLayout' });

const { activeName, item, handleClick } = useTabBar();

const route = useRoute();
const isTabBar = ref(route.meta.tabBarPage);
watchEffect(() => {
  isTabBar.value = route.meta.tabBarPage;
});

const isShow = ref(false);
function handleToolBarClick() {
  isShow.value = isShow.value ? false : true;
}
</script>

<template>
  <Page>
    <template #popup>
      <ToolBarPopup v-model:show="isShow" />
    </template>
    <template #toolbar v-if="isTabBar">
      <ToolBar @tool-bar-click="handleToolBarClick" />
    </template>
    <template #tabbar v-if="isTabBar">
      <KeepAlive>
        <TabBar
          v-model:active="activeName"
          :items="item.items"
          @tab-bar-item-click="handleClick"
      /></KeepAlive>
    </template>
    <template #content>
      <Content />
    </template>
  </Page>
</template>
