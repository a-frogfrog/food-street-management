<script setup lang="ts">
const modelValue = defineModel({
  type: String,
  required: true,
});

console.log(modelValue.value);
</script>

<template>
  <div class="tabbar">
    <div class="tabbar-content">
      <slot :class="modelValue"></slot>
    </div>
  </div>
</template>

<style scoped>
.tabbar {
  position: fixed;
  bottom: 0;
  width: 100%;
  box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
  border-radius: 20px 20px 0 0;
  background-color: rgba(255, 255, 255,.6);
  backdrop-filter: blur(10px);
  filter: saturate(200%); /* 高饱和度 */
}

.tabbar-content {
  width: 100%;
  height: 100%;
  display: flex;
  justify-content: space-around;
}
</style>
