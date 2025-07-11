<script setup lang="ts">
import type { TabBarItemProps } from './types';

const props = defineProps<TabBarItemProps>();

defineEmits<{
  tabBarItemClick: [name: string];
}>();
</script>

<template>
  <div
    class="tabbar-item "
    @click="$emit('tabBarItemClick', props.name)"
  >
    <div class="tabbar-item-content">
      <i class="icon" :class="icon"></i>
      <span>{{ label }}</span>
    </div>
  </div>
</template>
<style scoped>
.tabbar-item {
  padding: 10px;
  border-radius: 20px;
}

.is-active {
  /* background-color: #00890e; */
  color: #35774a;
  filter:drop-shadow(0 0 0.75rem #35774a)
}

.tabbar-item-content {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
}

.icon {
  font-size: 24px;
}

span {
  font-size: 12px;
}
</style>
