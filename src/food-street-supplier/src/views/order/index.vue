<script setup lang="ts">
import { ref } from 'vue';
import { OrderItem, OrderFilter } from './components';
import { WelCome } from '@/components';

function useOrderFilter() {
  const currentSelect = ref(0);
  const options = [
    {
      label: '未处理',
      value: 0,
    },
    {
      label: '进行中',
      value: 1,
    },
    {
      label: '已完成',
      value: 2,
    },
    {
      label: '已取消',
      value: 3,
    },
  ];

  function selectChange(val: number) {
    currentSelect.value = val;
  }
  return {
    options,
    currentSelect,
    selectChange,
  };
}
const title = '🙋‍♂️ Hi ! 黄记海鲜最近有新的订单！';

const { currentSelect, options, selectChange } = useOrderFilter();
</script>
<template>
  <div>
    <WelCome :title="title" :cover="'/imgs/background/welcome.png'" />
    <OrderFilter
      v-model="currentSelect"
      :options="options"
      @selectChange="selectChange"
      :total="13"
    />
    <OrderItem v-for="item in 13">{{ item }}</OrderItem>
  </div>
</template>
<style scoped></style>
