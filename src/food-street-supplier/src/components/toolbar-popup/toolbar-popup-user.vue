<script setup lang="ts">
const url =
  'https://demos.themeselection.com/materio-vuetify-vuejs-admin-template/demo-1/images/avatars/avatar-1.png';
</script>
<template>
  <div class="!px-2 !py-4 flex items-center border-b border-gray-200">
    <img class="w-20 h-20 rounded-md" :src="url" alt="" />
    <div class="!pl-2">
      <h4 class="text-base font-medium mt-2">John Doe</h4>
      <span class="text-sm">john.doe@example.com</span>
    </div>
  </div>
</template>
<style scoped></style>
