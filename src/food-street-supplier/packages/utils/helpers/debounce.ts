/**
 * 创建一个防抖函数，该函数在延迟时间内没有再次调用时，才会执行原函数
 * @param func 要防抖的函数
 * @param wait 延迟时间（毫秒）
 * @param immediate 是否立即执行（默认为 false）
 * @returns 防抖后的函数
 */
export function debounce<T extends (...args: any[]) => any>(
  func: T,
  wait: number,
  immediate: boolean = false,
): (...args: Parameters<T>) => ReturnType<T> | undefined {
  let timeout: ReturnType<typeof setTimeout> | null;

  return function (this: any, ...args: Parameters<T>) {
    const context = this;
    const later = () => {
      timeout = null;
      if (!immediate) func.apply(context, args);
    };

    const callNow = immediate && !timeout;

    if (timeout) clearTimeout(timeout);
    timeout = setTimeout(later, wait);

    if (callNow) return func.apply(context, args);
    return undefined;
  };
}
