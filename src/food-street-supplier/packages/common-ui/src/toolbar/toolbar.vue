<script setup lang="ts">
type ToolBarEmits = {
  toolBarClick: () => void;
};

defineEmits<ToolBarEmits>();
</script>

<template>
  <div class="page__toolbar" @click="$emit('toolBarClick')">
    <div class="!p-2 flex">
      <i class="iconfont iconfont icon-anse !px-1"></i>
      <h1 class="text-2xl font-smiley font-semibold">订单</h1>
    </div>
    <div class="toolbar__content">
      <i class="iconfont icon-bars"></i>
    </div>
  </div>
</template>

<style scoped>
.page__toolbar {
  z-index: 1000;
  position: absolute;
  top: 0;
  right: 0;
  height: 40px;
  width: 100%;
}

.toolbar__content {
  z-index: 1000;
  position: absolute;
  top: 0;
  right: 0;
  width: 40px;
  height: 40px;
  line-height: 40px;
  text-align: center;
  border-radius: 50%;
  cursor: pointer;
  transition: all 0.3s ease-in-out;
}

.icon-bars {
  font-size: 20px;
  color: #333;
}
</style>
