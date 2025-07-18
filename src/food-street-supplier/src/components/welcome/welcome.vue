<script setup lang="ts">
import defaultCover from '/imgs/background/welcome.jpg';

interface WelComeProps {
  cover?: string;
  title?: string;
  size: {
    width: string;
    height: string;
  };
}

defineProps<WelComeProps>();
</script>

<template>
  <div class="welcome">
    <img
      :src="cover || defaultCover"
      :style="{ height: size.height, width: size.width }"
    />
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

.welcome img {
  object-fit: cover;
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
