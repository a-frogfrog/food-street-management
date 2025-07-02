<script setup lang="ts"></script>

<template>
  <div class="content">
    <slot name="header"></slot>
    <slot name="main"></slot>
  </div>
</template>

<style scoped>
.content {
  /* min-height: calc(100vh - 4rem); */
  overflow: hidden auto;
  position: relative;
}
</style>
