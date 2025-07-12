import { useRouter } from "vue-router"

export function useTabBar() {
  const router = useRouter();
  const goToPage = (page: string) => {
    // TODO: Implement navigation to the specified page
    router.push(page);
  }


  return {
    goToPage,
  }
}