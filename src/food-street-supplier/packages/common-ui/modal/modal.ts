import { createApp } from 'vue';
import Modal from './modal.vue';
export function createModal() {
  const modal = createApp(Modal);
  const element = document.createElement('div');
  document.body.appendChild(element);
  modal.mount(element);
}
