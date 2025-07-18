<script setup lang="ts">
import { CloseIcon } from '@frog/icons';
import { FrogButton } from '@frog/common-ui';

interface ModalProps {
  show: boolean;
  title?: string;
  message?: string;
  confirmText?: string;
  cancelText?: string;
}
type ModalEmits = {
  close: [];
};

const props = defineProps<ModalProps>();
const emit = defineEmits<ModalEmits>();
</script>
<template>
  <Teleport to="body">
    <Transition name="modal">
      <div v-if="show" class="modal-overlay" tabindex="-1">
        <div class="modal-container">
          <slot name="header">
            <div class="flex justify-between items-center">
              <span>tip</span>
              <span>{{ props.title }}</span>
              <div class="close-btn" @click="emit('close')">
                <CloseIcon />
              </div>
            </div>
          </slot>
          <slot name="body">
            <div>
              <div class="!py-4">
                <span>
                  {{ props.message }}
                  Lorem, ipsum dolor sit amet consectetur adipisicing elit. Modi
                  accusamus illum, aspernatur laborum nesciunt reprehenderit
                  eveniet odio. Modi rerum laboriosam velit qui nesciunt dolores
                  ex, ab obcaecati temporibus impedit quae?
                </span>
              </div>
            </div>
          </slot>
          <slot name="footer">
            <div class="flex justify-end mt-4 gap-2">
              <FrogButton type="primary" @click="emit('close')"
                >确定</FrogButton
              >
              <FrogButton @click="emit('close')">取消</FrogButton>
            </div>
          </slot>
        </div>
      </div>
    </Transition>
  </Teleport>
</template>

<style scoped>
.modal-overlay {
  position: fixed;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background-color: rgba(0, 0, 0, 0.5);
  display: flex;
  align-items: center;
  justify-content: center;
  z-index: 9999;
  transition: all 0.3s ease-in-out;
}

.modal-container {
  background-color: white;
  padding: 10px;
  border-radius: 5px;
  width: 50%;
  max-width: 500px;
  min-width: 300px;
  transition: all 0.3s ease-in-out;
}

.modal-enter-from {
  opacity: 0;
}

.modal-leave-to {
  opacity: 0;
}

.modal-enter-from .modal-container,
.modal-leave-to .modal-container {
  -webkit-transform: scale(1.1);
  transform: scale(1.1);
}

.close-btn {
  border: none;
  background-color: transparent;
  cursor: pointer;
  font-size: 20px;
  /* font-weight: bold; */
  border-radius: 50%;
}
</style>
