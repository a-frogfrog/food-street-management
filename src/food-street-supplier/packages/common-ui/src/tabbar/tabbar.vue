<script setup lang="ts">
import type { TabBarEmits, TabBarProps } from './types';
import { useTabBar } from './use-tabbar';

const active = defineModel('active', {
  type: String,
  required: true,
});

const props = defineProps<TabBarProps>();
const emit = defineEmits<TabBarEmits>();

const { goToPage } = useTabBar();
</script>

<template>
  <div class="tabbar">
    <div class="tabbar-content">
      <template v-for="item in props.items" :key="item.name">
        <div
          class="tabbar-item"
          :class="[active === item.name ? 'is-active' : '']"
          @click="(emit('tabBarItemClick', item.name), goToPage(item.name))"
        >
          <template v-if="item.cover">
            <div class="tabbar-cover">
              <img :src="item.cover" alt="" />
            </div>
          </template>
          <template v-else>
            <div class="tabbar-item-content">
              <i class="icon" :class="item.icon"></i>
              <!-- <span>{{ item.label }}</span> -->
            </div>
          </template>
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
  padding: 10px;
}

.tabbar-item {
  border-radius: 50%;
  cursor: pointer;
  transition:
    background-color 0.3s ease-in-out,
    color 0.3s ease-in-out,
    box-shadow 0.3s ease-in-out,
    filter 0.3s ease-in-out;
}

.is-active {
  color: #45a0b6;
  filter: drop-shadow(0 0 0.75rem #45a0b6);
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

.tabbar-cover {
  height: 100%;
  display: flex;
  justify-content: center;
  align-items: center;
  cursor: pointer;
  transition:
    background-color 0.3s ease-in-out,
    color 0.3s ease-in-out,
    box-shadow 0.3s ease-in-out,
    filter 0.3s ease-in-out;
}

.tabbar-cover img {
  width: 33px;
  height: 33px;
  object-fit: cover;
  border: 2px solid #fff;
  border-radius: 50%;
  transition: transform 0.3s ease-in-out;
}
</style>
