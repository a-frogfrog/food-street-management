import { ref } from "vue";

let instance: any = null;
export function useCollapse() {
  if (instance) {
    return instance;
  }

  const isCollapsed = ref(false);
  const toggleCollapse = () => {
    isCollapsed.value = !isCollapsed.value;
  };

  instance = {
    isCollapsed,
    toggleCollapse,
  };

  return instance;
}
