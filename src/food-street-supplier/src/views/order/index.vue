<script setup lang="ts">
import { ref } from 'vue';
import { OrderItem, OrderFilter } from './components';
import { WelCome } from '@/components';
import { Modal } from '@frog/common-ui';

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

function useModal() {
  const visible = ref(false);

  const toggleModal = () => {
    visible.value = !visible.value;
  };
  return {
    visible,
    toggleModal,
  };
}
const { title } = useWelCome();
const { currentSelect, options, selectChange } = useOrderFilter();
const { visible, toggleModal } = useModal();
</script>
<template>
  <div>
    <Modal :show="visible" @close="toggleModal" />
    <WelCome :title="title" :size="{ width: '100%', height: '200px' }" />
    <OrderFilter
      v-model="currentSelect"
      :options="options"
      @selectChange="(selectChange, toggleModal())"
      :total="13"
    />
    <OrderItem v-for="item in 13">{{ item }}</OrderItem>
  </div>
</template>
<style scoped></style>
