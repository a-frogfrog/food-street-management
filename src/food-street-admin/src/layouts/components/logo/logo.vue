<script setup lang="ts">
import { useCollapse } from "@frog/hooks";

const { isCollapsed } = useCollapse();
</script>
<template>
  <div class="flex justify-center items-center gap-2 !py-2">
    <img src="/vite.svg" alt="logo" class="w-10 h-10" />
    <Transition name="fade" mode="out-in">
      <h1
        v-if="!isCollapsed"
        class="text-2xl !mb-0 !font-semibold whitespace-nowrap font-mono"
      >
        Food Street
      </h1>
    </Transition>
  </div>
</template>
<style scoped></style>
