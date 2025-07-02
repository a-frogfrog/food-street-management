<script setup lang="ts">
import { ConfigProvider } from "ant-design-vue";
import { theme } from "ant-design-vue";
import { useThemeStore } from "./stores";
import { computed } from "vue";

const themeStore = useThemeStore();

const themeConfig = computed(() => {
  return {
    algorithm: themeStore.isDark ? theme.darkAlgorithm : theme.defaultAlgorithm,
  };
});
</script>

<template>
  <ConfigProvider :theme="themeConfig">
    <RouterView />
  </ConfigProvider>
</template>

<style scoped></style>
