<script setup lang="ts"></script>

<template>
  <main class="content-box">
    <div class="header-bar">
      <i class="iconfont icon-bars"></i>
    </div>
    <RouterView v-slot="{ Component }">
      <Transition name="fade" mode="out-in">
        <Component :is="Component" />
      </Transition>
    </RouterView>
  </main>
</template>

<style scoped>
.content-box {
  position: relative;
  width: 100%;
  height: 100%;
  overflow: auto;
  box-sizing: border-box;
}

.header-bar {
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
