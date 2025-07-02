import { createWebHistory, createRouter } from "vue-router";
import routes from "./routes";
import guard from "./handle/guard";
import "./handle/event";

const router = createRouter({
  history: createWebHistory(),
  routes,
});

// 路由守卫
router.beforeEach(guard.beforeEach);
router.afterEach(guard.afterEach);

export default router;
