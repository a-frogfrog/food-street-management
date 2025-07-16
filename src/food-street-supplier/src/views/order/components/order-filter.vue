<script setup lang="ts">
import { useScrollShadow } from './use-scroll-shadow';

const current = defineModel<number>();
defineProps({
  total: {
    type: Number,
    default: 0,
  },
  options: {
    type: Array<{ label: string; value: number; icon?: string }>,
    default: () => [],
  },
});
defineEmits<{
  (e: 'selectChange', value: number): void;
}>();

function useClassNames() {
  const classNames = {
    filter: [
      'order-filter',
      'sticky',
      'top-0',
      'bg-[#FFFAFA]',
      'z-10',
      '!pt-3',
      'transition-all',
      'duration-200',
    ],
    filterShadow: ['shadow-lg', 'rounded-b-2xl'],
    filterContent: [
      'flex',
      'justify-between',
      'items-center',
      '!px-4',
      '!py-2',
    ],
    filerItem: [
      '!px-2',
      '!py-1',
      'rounded-4xl',
      'text-gray-400',
      'text-lg',
      'font-inter',
    ],
    filterFooter: ['!px-4', '!py-2', 'flex', 'justify-between', 'items-center'],
    filterReset: [
      'bg-[#F3F0F3]',
      '!px-2',
      'rounded-4xl',
      'border',
      'border-gray-200',
      'text-gray-500',
      'text-base',
      'font-inter',
    ],
  };

  return {
    classNames,
  };
}

const { classNames } = useClassNames();
const { isShadow } = useScrollShadow('.page', '.order-filter');

function getShadow() {
  return isShadow.value ? 'shadow-lg rounded-b-2xl' : '';
}
function isActive(value: number) {
  return value === current.value && 'is-active';
}
</script>
<template>
  <div :class="[getShadow(), classNames.filter]">
    <div :class="classNames.filterContent">
      <template v-for="item in options" :key="item.value">
        <div
          :class="[isActive(item.value), classNames.filerItem]"
          @click="$emit('selectChange', item.value)"
        >
          <i class="!px-1" :class="item.icon"></i>
          <span>{{ item.label }}</span>
        </div>
      </template>
    </div>
    <div :class="classNames.filterFooter">
      <div>
        <span>{{ total }} 条结果</span>
      </div>
      <div>
        <span :class="classNames.filterReset">重置</span>
      </div>
    </div>
  </div>
</template>

<style scoped>
.is-active {
  color: #000;
  position: relative;
}

.is-active::before {
  content: '';
  width: 40px;
  height: 4px;
  border-radius: 10px;
  background-color: #000;
  position: absolute;
  bottom: 0;
  transform: translateX(60%);
}
</style>
