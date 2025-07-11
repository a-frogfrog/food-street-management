import { defineConfig } from 'vite';
import vue from '@vitejs/plugin-vue';
import { resolve } from 'path'; // 新增的导入语句
import tailwindcss from '@tailwindcss/vite';

// https://vite.dev/config/
export default defineConfig({
  server: {
    host: true,
  },
  plugins: [vue(), tailwindcss()],
  resolve: {
    alias: {
      '@': resolve(__dirname, 'src'),
      '@frog/layouts': resolve(__dirname, './packages/layouts'),
      '@frog/styles': resolve(__dirname, './packages/styles'),
      '@frog/common-ui': resolve(__dirname, './packages/common-ui'),
    },
  },
});
