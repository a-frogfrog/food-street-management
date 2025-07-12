<script setup lang="ts">
import LayoutContent from './content/content.vue';

defineOptions({ name: 'BasicLayout' });
</script>

<template>
  <div class="basic-layout">
    <LayoutContent></LayoutContent>
    <slot name="tabbar"></slot>
  </div>
</template>

<style scoped>
.basic-layout {
  width: 100%;
  height: 100vh;
  background-color: #fffafa;
}
</style>
