import { debounce } from '@frog/utils';
import { onBeforeMount, onMounted, ref } from 'vue';

/**
 * 滚动显示阴影
 * @param scrollSelector 滚动元素选择器
 * @param shadowSelector  阴影元素选择器
 * @returns isShadow 是否显示阴影
 */
export function useScrollShadow(
  scrollSelector: string,
  shadowSelector: string,
) {
  const scrollElement = ref<HTMLElement | null>(null);
  const isShadow = ref(false);
  const shadowElement = ref<HTMLElement | null>(null);

  const handleScroll = () => {
    if (!scrollElement.value || !shadowElement.value) {
      return;
    }

    const rect = shadowElement.value.getBoundingClientRect();
    !(rect.top > 0) ? (isShadow.value = true) : (isShadow.value = false);
  };

  const debounceScroll = debounce(handleScroll, 100);

  onMounted(() => {
    scrollElement.value = document.querySelector(scrollSelector);
    shadowElement.value = document.querySelector(shadowSelector);

    scrollElement.value?.addEventListener('scroll', debounceScroll);
  });
  onBeforeMount(() => {
    scrollElement.value?.removeEventListener('scroll', debounceScroll);
  });
  return {
    isShadow,
  };
}
