<script setup lang="ts">
const current = defineModel();

defineProps({
  total: {
    type: Number,
    default: 0,
  },
  options: {
    type: Array<{ label: string; value: number }>,
    default: () => [],
  },
});

defineEmits<{
  (e: 'selectChange', value: number): void;
}>();
</script>
<template>
  <div class="order-filter">
    <div class="flex justify-between items-center !px-4 !py-2">
      <template v-for="item in options" :key="item.value">
        <div
          :class="[item.value === current ? 'is-active' : '']"
          class="bg-[#F3F0F3] !px-2 !py-1 rounded-4xl border border-gray-200 text-gray-500 text-lg font-inter"
          @click="$emit('selectChange', item.value)"
        >
          <i class="iconfont icon-baoqian !px-1"></i>
          <span>{{ item.label }}</span>
        </div>
      </template>
    </div>
    <div class="!px-4 flex justify-between items-center !py-2">
      <div>
        <span>{{ total }} 条结果</span>
      </div>
      <div>
        <span
          class="bg-[#F3F0F3] !px-2 rounded-4xl border border-gray-200 text-gray-500 text-base font-inter"
          >重置</span
        >
      </div>
    </div>
  </div>
</template>

<style scoped>
.is-active {
  color: #000;
  border: 1px solid #c0bfc0;
}
</style>
