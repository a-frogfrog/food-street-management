<script setup lang="ts">
import { Popup, Image as VanImage } from 'vant';
import { WelCome } from '../welcome';
import ToolBarPopupBack from './toolbar-popup-back.vue';
import ToolbarPopupItem from './toolbar-popup-item.vue';

const show = defineModel('show', {
  type: Boolean,
  required: true,
});

// interface ToolBarPopupProps {
//   userInfo: object;
// }

// const props = defineProps<ToolBarPopupProps>();

function goBack() {
  console.log('dd');
}
</script>
<template>
  <div>
    <Popup
      teleport="body"
      v-model:show="show"
      position="right"
      :style="{ width: '70%', height: '100%' }"
    >
      <div>
        <div class="rounded-md">
          <div>
            <WelCome />
          </div>
          <div class="!p-2 flex w-full justify-center items-center">
            <div class="!px-2">
              <input type="text" placeholder="历史记录" />
            </div>
            <div>
              <VanImage
                width="4rem"
                height="4rem"
                round
                src="https://demos.themeselection.com/materio-vuetify-vuejs-admin-template/demo-1/images/avatars/avatar-1.png"
              ></VanImage>
            </div>
          </div>
        </div>
        <ToolbarPopupItem />
      </div>

      <div class="absolute bottom-0 w-full">
        <div class="!p-2">
          <button class="w-full bg-red-400 !text-white">
            <i class="iconfont icon-tuichudenglu !px-1"></i>
            <span>退出登录</span>
          </button>
        </div>
      </div>
      <ToolBarPopupBack @go-back="goBack" />
    </Popup>
  </div>
</template>

<style scoped></style>
