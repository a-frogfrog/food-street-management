<script setup lang="ts">
defineProps<{
  height?: string | number;
}>();
</script>

<template>
  <div class="main" :style="{ height: height }">
    <RouterView v-slot="{ Component }">
      <Transition name="slide-fade" mode="out-in">
        <Component :is="Component" />
      </Transition>
    </RouterView>
  </div>
</template>

<style scoped>
.main {
  background-color: var(--bg-secondary);
  overflow: hidden auto;
}

.slide-fade-enter-active {
  transition: all 0.3s ease-out;
}

.slide-fade-leave-active {
  transition: all 0.3s cubic-bezier(0.3, 0.8, 0.7, 1);
}

.slide-fade-enter-from,
.slide-fade-leave-to {
  transform: translateX(20px);
  opacity: 0;
}
</style>
