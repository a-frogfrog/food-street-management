<script setup lang="ts">
import { Avatar, Switch, InputSearch } from "ant-design-vue";
import { ref, watch } from "vue";
import { useThemeStore } from "@/stores/modules/theme";
import { useCollapse } from "@frog/hooks";

defineProps<{
  isSticky?: boolean;
  height?: number | string;
}>();

const themeStore = useThemeStore();
const isDark = ref(themeStore.isDark);
const { toggleCollapse } = useCollapse();

watch(isDark, () => {
  themeStore.toggleTheme();
});

const menuCollapseClick = () => {
  toggleCollapse();
};

const avatarSrc = ref(
  "https://demos.themeselection.com/materio-vuetify-nuxtjs-admin-template/demo-1/images/avatars/avatar-1.png",
);
</script>

<template>
  <nav
    class="header"
    :class="[isSticky ? 'header-sticky' : '']"
    :style="{ height: height }"
  >
    <div class="flex h-full items-center">
      <div @click="menuCollapseClick" class="font-bold !p-2 cursor-pointer">
        <i class="icon iconfont icon-bars"></i>
      </div>
      <div
        class="font-bold !p-2 cursor-pointer hover:rotate-360 transition-all duration-300"
      >
        <i class="icon iconfont icon-icon1"></i>
      </div>
      <div class="flex-1 justify-end flex items-center gap-4">
        <div>
          <InputSearch></InputSearch>
        </div>
        <div>
          <Switch v-model:checked="isDark">
            <template #checkedChildren>
              <i class="iconfont icon-anse"></i>
            </template>
            <template #unCheckedChildren>
              <i class="iconfont icon-liangse"></i>
            </template>
          </Switch>
        </div>
        <div>
          <i class="iconfont icon-quanping icon"></i>
        </div>
        <div>
          <i class="iconfont icon-fenxiang icon"></i>
        </div>
        <div>
          <Avatar
            class="cursor-pointer"
            shape="square"
            :size="40"
            :src="avatarSrc"
          />
        </div>
      </div>
    </div>
  </nav>
</template>

<style scoped>
.header {
  backdrop-filter: saturate(50%) blur(8px);
}

.header-sticky {
  position: sticky;
  top: 0;
  z-index: 1000;
}

.header .icon {
  font-size: 20px;
  cursor: pointer;
}
</style>
