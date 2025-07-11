<script setup lang="ts">
const state = [
  {
    label: '未处理',
    value: 0,
  },
  {
    label: '进行中',
    value: 1,
  },
  {
    label: '已完成',
    value: 2,
  },
  {
    label: '已取消',
    value: 3,
  },
];
</script>
<template>
  <div class="order-filter flex justify-between items-center !px-4 !py-2">
    <template v-for="item in state" :key="item.value">
      <div
        :class="[item.value === 0 ? 'is-active' : '']"
        class="bg-[#F7F6F9] !px-2 !py-1 rounded-4xl border border-gray-200 text-gray-500 text-lg font-inter"
      >
        <i class="iconfont icon-baoqian !px-1"></i>
        <span>{{ item.label }}</span>
      </div>
    </template>
  </div>
</template>

<style scoped>
.is-active {
  color: #000;
}
</style>
