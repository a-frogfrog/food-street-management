<script setup lang="ts">
defineProps<{
  isCollapsed?: boolean; // 是否折叠
  elWidth?: string | number; // 侧边栏宽度
}>();
</script>

<template>
  <div class="aside" :style="{ width: elWidth }">
    <slot name="logo"></slot>
    <slot name="menu"></slot>
  </div>
</template>

<style scoped>
.aside {
  background-color: var(--bg-primary);
  border-right: 1px solid var(--border-color);
  color: var(--text-primary);
  transition: width 0.3s ease;
}
</style>
