<script setup lang="ts">
import { Menu } from "ant-design-vue";
import { ref } from "vue";
import { useRouter } from "vue-router";
import { useCollapse } from "@frog/hooks";
import type { ItemType } from "ant-design-vue";

defineProps<{
  menus: ItemType[] | undefined;
}>();

const router = useRouter();
const currentRoute = ref(router.currentRoute.value.path);

router.afterEach((to) => {
  currentRoute.value = to.path;
});

const handleClick = (e: any) => {
  router.push(e.key);
};

const { isCollapsed } = useCollapse();
</script>

<template>
  <div class="menu-container">
    <Menu
      mode="inline"
      :inline-collapsed="isCollapsed"
      :selectedKeys="[currentRoute]"
      :items="menus"
      @click="handleClick"
    ></Menu>
  </div>
</template>

<style scoped>
.menu-container {
  height: 100%;
  overflow: hidden auto;
  padding: 10px 0;
  background-color: var(--bg-primary);
}
</style>
