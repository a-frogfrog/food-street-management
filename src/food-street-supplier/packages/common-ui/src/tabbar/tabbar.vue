<script setup lang="ts">
import type { TabBarProps } from './types';

const model = defineModel({
  type: String,
  required: true,
});

const props = defineProps<TabBarProps>();

defineEmits<{
  (e: 'tabBarItemClick', name: string): void;
}>();
</script>

<template>
  <div class="tabbar">
    <div class="tabbar-content">
      <template v-for="item in props.items" :key="item.name">
        <div
          class="tabbar-item"
          :class="[model === item.name ? 'is-active' : '']"
          @click="$emit('tabBarItemClick', item.name)"
        >
          <div class="tabbar-item-content">
            <i class="icon" :class="item.icon"></i>
            <span>{{ item.label }}</span>
          </div>
        </div>
      </template>
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
  background-color: rgba(255, 255, 255, 0.6);
  backdrop-filter: blur(10px);
  filter: saturate(200%); /* 高饱和度 */
}

.tabbar-content {
  width: 100%;
  height: 100%;
  display: flex;
  justify-content: space-around;
}

.tabbar-item {
  padding: 10px;
  border-radius: 20px;
}

.is-active {
  /* background-color: #00890e; */
  color: #45a0b6;
  /* filter: drop-shadow(0 0 0.75rem #45a0b6); */
}

.tabbar-item-content {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
}

.icon {
  font-size: 24px;
}
</style>
