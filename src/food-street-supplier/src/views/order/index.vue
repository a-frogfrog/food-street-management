<script setup lang="ts">
import { OrderItem, OrderFilter } from './components';
import { WelCome } from '@/components';

const title = '🙋‍♂️ Hi ！ 黄记海鲜最近有新的订单！';
</script>
<template>
  <div>
    <WelCome :title="title" :cover="'/imgs/background/welcome.png'"></WelCome>
    <OrderFilter></OrderFilter>
    <OrderItem v-for="item in 13"></OrderItem>
  </div>
</template>
<style scoped></style>
