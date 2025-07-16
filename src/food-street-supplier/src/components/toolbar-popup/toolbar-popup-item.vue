<script setup lang="ts">
interface ToolBarPopupItem {
  icon: string;
  label: string;
}

const items: ToolBarPopupItem[] = [
  {
    icon: 'iconfont icon-anse',
    label: '用户信息',
  },
  {
    icon: 'iconfont icon-anse',
    label: '深色模式',
  },
  {
    icon: 'iconfont icon-anse',
    label: '历史订单',
  },
  {
    icon: 'iconfont icon-anse',
    label: '设置',
  },
];
</script>

<template>
  <div class="!mt-2">
    <template v-for="item in items">
      <div class="flex !py-2 !my-1 !px-2 text-gray-600">
        <div class="!px-2 !py-1">
          <i class="" :class="item.icon"></i>
        </div>
        <div class="border-b border-gray-200 flex-1 !py-1">
          <span class="text-xl">{{ item.label }}</span>
        </div>
      </div>
    </template>
  </div>
</template>

<style scoped></style>
