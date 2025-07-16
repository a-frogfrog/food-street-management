<script setup lang="ts"></script>

<template>
  <div class="page">
    <slot></slot>
    <slot name="popup"></slot>
    <slot name="toolbar"></slot>
    <slot name="tabbar"></slot>
    <slot name="content"></slot>
  </div>
</template>

<style scoped>
.page {
  position: relative;
  width: 100%;
  height: 100vh;
  overflow: auto;
  box-sizing: border-box;
}
</style>
