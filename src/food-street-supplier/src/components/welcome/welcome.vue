<script setup lang="ts">
interface WelComeProps {
  cover?: string;
  title?: string;
}

defineProps<WelComeProps>();
</script>

<template>
  <div class="welcome">
    <img src="/imgs/background/welcome.jpg" />
    <div class="mask">
      <div class="mask-content">
        <h1 class="text-xl font-bold font-smiley">
          {{ title }}
        </h1>
      </div>
    </div>
  </div>
</template>

<style scoped>
.welcome {
  position: relative;
}

.mask {
  position: absolute;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background: linear-gradient(to bottom, transparent 0%, #fffafa 100%);
}

.mask-content {
  position: absolute;
  bottom: 0;
  text-align: center;
}
</style>
