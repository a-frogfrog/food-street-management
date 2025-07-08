import { defineConfig } from "vite";
import vue from "@vitejs/plugin-vue";
import path from "path"; // 新增的导入语句

// https://vite.dev/config/
export default defineConfig({
    plugins: [vue()],
    resolve: {
        alias: {
            "@": path.resolve(__dirname, "src"),
            "@frog/layouts": path.resolve(__dirname, "./packages/layouts"),
        },
    },
});
