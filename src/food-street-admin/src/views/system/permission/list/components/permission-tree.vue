<script setup lang="ts">
import { ElTree } from "element-plus";
import type { PermissionViewItem } from "../data";

defineOptions({
  name: "PermissionTree",
});

defineProps<{
  data: PermissionViewItem[];
}>();

defineEmits<{
  (e: "click", item: PermissionViewItem): void;
}>();
</script>

<template>
  <header class="border-b tree-header sticky top-0">
    <h1>权限列表</h1>
  </header>
  <ElTree
    :data="data"
    :expand-on-click-node="false"
    @node-click="$emit('click', $event)"
    class="!mt-1"
  >
    <template #default="{ data }">
      <span>
        <i class="iconfont !pr-1 text-[#1677FF]" :class="data.icon"></i>
      </span>
      <span>{{ data.label }}</span>
    </template>
  </ElTree>
</template>

<style scoped>
.tree-header {
  border-bottom: 1px solid var(--border-color);
  background-color: var(--bg-primary);
}

:deep(.el-tree-node__content) {
  padding: 20px 0;
}

:deep(.el-tree-node__content:hover) {
  background-color: var(--bg-hover-primary);
}
</style>
