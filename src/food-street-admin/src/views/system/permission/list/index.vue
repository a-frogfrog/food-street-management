<script setup lang="ts">
import { useGetPermission, type PermissionViewItem } from "./data";
import {
  PermissionTree,
  PermissionDescription,
  PermissionUserTable,
  PermissionModal,
} from "./components";

import { Container } from "@frog/components";

import { ref } from "vue";

function handleTreeClick(item: PermissionViewItem) {
  descriptionData.value = item;
}

function handleDescriptionClick() {
  open.value = true;
}

function useModal() {
  const open = ref(false);

  return {
    open,
  };
}

const { treeData, descriptionData } = useGetPermission();
const { open } = useModal();
</script>

<template>
  <div class="permission-list flex gap-4 h-full">
    <Container class="flex-1 relative" is-shadow>
      <PermissionTree :data="treeData" @click="handleTreeClick" />
    </Container>
    <Container background="var(--bg-secondary)" class="flex-4">
      <PermissionDescription
        :item-data="descriptionData"
        @click="handleDescriptionClick"
      />
      <Container class="!mt-8" is-shadow>
        <PermissionUserTable />
      </Container>
    </Container>
    <PermissionModal
      :open="open"
      @cancel="open = false"
      @ok="open = false"
      :data="descriptionData"
    />
  </div>
</template>

<style scoped></style>
