<script setup lang="ts">
import { Popup } from 'vant';
import ToolbarPopupItem from './toolbar-popup-item.vue';
import ToolbarPopupLogout from './toolbar-popup-logout.vue';
import ToolbarPopupUser from './toolbar-popup-user.vue';

const show = defineModel('show', {
  type: Boolean,
  required: true,
});
</script>
<template>
  <div>
    <Popup
      teleport="body"
      v-model:show="show"
      position="right"
      :style="{ width: '70%', height: '100%' }"
    >
      <ToolbarPopupLogout />
      <ToolbarPopupUser />
      <ToolbarPopupItem />
    </Popup>
  </div>
</template>

<style scoped></style>
