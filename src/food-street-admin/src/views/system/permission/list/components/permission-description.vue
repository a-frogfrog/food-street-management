<script setup lang="ts">
import { Descriptions, DescriptionsItem, Button, Tag } from "ant-design-vue";
import type { PermissionViewItem } from "../data";

defineProps<{
  itemData: PermissionViewItem;
}>();

defineEmits<{
  (e: "click"): void;
}>();
</script>

<template>
  <Descriptions title="权限详情" bordered>
    <template #extra>
      <Button type="primary" @click="$emit('click')">编辑</Button>
    </template>
    <DescriptionsItem label="名称">{{ itemData.label }}</DescriptionsItem>
    <DescriptionsItem label="URL">
      <Tag>{{ itemData.url }}</Tag>
    </DescriptionsItem>
    <DescriptionsItem label="类型">{{ itemData.type }}</DescriptionsItem>
    <DescriptionsItem label="状态">{{ itemData.status }}</DescriptionsItem>
    <DescriptionsItem label="序号">{{ itemData.sort }}</DescriptionsItem>
    <DescriptionsItem label="Icon">{{ itemData.icon }}</DescriptionsItem>
    <DescriptionsItem label="描述">{{ itemData.description }}</DescriptionsItem>
  </Descriptions>
</template>

<style scoped></style>
