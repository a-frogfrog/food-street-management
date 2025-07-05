<script setup lang="ts">
defineProps({
  background: {
    type: String,
    required: false,
  },
  isShadow: {
    type: Boolean,
    required: false,
    default: false,
  },
  isOverflow: {
    type: Boolean,
    required: false,
    default: true,
  },
});
</script>

<template>
  <div
    class="constainer-box"
    :style="{ backgroundColor: background }"
    :class="[isShadow ? 'is-shadow' : '', isOverflow ? 'is-overflow' : '']"
  >
    <slot></slot>
  </div>
</template>

<style scoped>
.constainer-box {
  width: inherit;
  background-color: var(--bg-primary);
  border-radius: 6px;
  padding: 0.75em;
  overflow: hidden;
  border: 1px solid var(--border-color);
}

.is-shadow {
  box-shadow: 0 0 10px 0 rgba(0, 0, 0, 0.07);
}

.is-overflow {
  overflow-y: auto;
}
</style>
