<script setup lang="ts">
import { computed } from 'vue';
import type { ButtonEmits, ButtonProps } from './types';
const props = defineProps<ButtonProps>();
const emit = defineEmits<ButtonEmits>();

const useClassName = computed(() => {
  return {
    'frog-button': true,
    'frog-button--primary': props.type === 'primary',
    'frog-button--danger': props.type === 'danger',
    'frog-button--warning': props.type === 'warning',
    'frog-button--success': props.type === 'success',
    'is--round': props.round,
    'is--disabled': props.disabled,
  };
});
</script>
<template>
  <div
    :class="useClassName"
    :style="{ backgroundColor: props.color, border: props.color }"
    @click="emit('click')"
  >
    <slot></slot>
  </div>
</template>

<style scoped></style>
