import { ElLoading } from "element-plus";
import type { LoadingOptions } from "element-plus";
export function useLoading() {
  let loadingInstance = null as any;
  function startLoading(
    options: LoadingOptions = {
      text: "Loading...",
      lock: true,
      background: "rgba(0, 0, 0, 0.7)",
    },
  ) {
    const { text, lock, background } = options;
    loadingInstance = ElLoading.service({
      lock: lock,
      text: text,
      background: background,
    });
  }

  function stopLoading() {
    loadingInstance.close();
  }

  return {
    startLoading,
    stopLoading,
  };
}
