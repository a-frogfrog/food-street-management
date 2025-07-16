<script setup lang="ts">
import { ref } from 'vue';
import { Page } from '@frog/common-ui';
import { OrderItem, OrderFilter } from './components';
import { WelCome } from '@/components';

function useWelCome() {
  const title = '🙋‍♂️ Hi ! 黄记海鲜最近有新的订单！';
  return {
    title,
  };
}

function useOrderFilter() {
  const currentSelect = ref(0);
  const options = [
    {
      label: '未处理',
      value: 0,
      icon: 'iconfont icon-baoqian',
    },
    {
      label: '进行中',
      value: 1,
      icon: 'iconfont icon-baoqian',
    },
    {
      label: '已完成',
      value: 2,
      icon: 'iconfont icon-baoqian',
    },
    {
      label: '已取消',
      value: 3,
      icon: 'iconfont icon-baoqian',
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

const { title } = useWelCome();
const { currentSelect, options, selectChange } = useOrderFilter();
</script>
<template>
  <div>
    <WelCome :title="title" cover="/imgs/background/welcome.png" />
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
