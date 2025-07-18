<script setup lang="ts">
interface ToolBarPopupItem {
  icon?: string;
  label: string;
  children?: ToolBarPopupItem[];
}

const items: ToolBarPopupItem[] = [
  {
    icon: 'iconfont icon-gouwuche',
    label: '订单',
    children: [
      {
        icon: 'iconfont icon-gouwuche',
        label: '全部订单',
      },
      {
        icon: 'iconfont icon-zhekou1',
        label: '待收货',
      },
      {
        icon: 'iconfont icon-dingdan',
        label: '退款/售后',
      },
    ],
  },
  {
    label: '个性化',
    children: [
      {
        icon: 'iconfont icon-pifu',
        label: '深色模式',
      },
    ],
  },
  {
    label: '基础设置',
    children: [
      {
        icon: 'iconfont icon-gangweiguanli',
        label: '用户信息',
      },
      {
        icon: 'iconfont icon-xitong',
        label: '设置',
      },
      {
        icon: 'iconfont icon-baoqian',
        label: '帮助',
      },
    ],
  },
];
</script>

<template>
  <div class="!mt-2">
    <template v-for="item in items">
      <div v-if="item.children">
        <div class="flex !px-2 text-gray-600">
          <div class="flex-1 !py-1">
            <span class="text-gray-500 text-sm">{{ item.label }}</span>
          </div>
        </div>
        <div
          v-for="child in item.children"
          class="flex !py-2 !px-2 text-gray-600 text-lg"
        >
          <div class="!px-2 text-xl">
            <i :class="child.icon"></i>
          </div>
          <div>
            <span class="text-lg">{{ child.label }}</span>
          </div>
        </div>
      </div>
      <div v-else>
        <div class="flex !py-2 !px-2 text-gray-600 text-lg">
          <div class="!px-2 text-xl">
            <i :class="item.icon"></i>
          </div>
          <div>
            <span class="text-lg">{{ item.label }}</span>
          </div>
        </div>
      </div>
    </template>
  </div>
</template>

<style scoped></style>
