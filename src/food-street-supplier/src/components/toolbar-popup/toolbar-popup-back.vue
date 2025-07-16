<script setup lang="ts">
type ToolBarPopupBackEmits = {
  goBack: () => void;
};

defineEmits<ToolBarPopupBackEmits>();
</script>

<template>
  <div class="absolute top-0 w-full" @click="$emit('goBack')">
    <div class="!px-4 !py-2 text-black font-smiley">
      <i class="iconfont icon-fanhui !px-1 !text-3xl"></i>
      <!-- <span class="font-smiley text-xl">返回</span> -->
    </div>
  </div>
</template>

<style scoped></style>
