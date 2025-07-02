import type { NavigationGuardWithThis, NavigationHookAfter } from "vue-router";
import { eventEmitter } from "@frog/utils";

// import { useProgress } from "@frog/utils";
import { useAuthStore } from "@/stores";

const beforeEach: NavigationGuardWithThis<undefined> = (to: any) => {
  eventEmitter.emit("progress:start");

  const authStore = useAuthStore();
  if (to.meta.requiresAuth) {
    if (!authStore.isAuthenticated) {
      return { path: "/auth/login" };
    }
    authStore.checkLogin();
  }

  return true;
};

const afterEach: NavigationHookAfter = (): void => {
  eventEmitter.emit("progress:finish");
};

export default {
  beforeEach,
  afterEach,
};
