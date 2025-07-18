import { defineConfig } from 'vite';
import vue from '@vitejs/plugin-vue';
import { resolve } from 'path';
import tailwindcss from '@tailwindcss/vite';
import Inspect from 'vite-plugin-inspect';

// https://vite.dev/config/
export default defineConfig({
  server: {
    host: true,
  },
  plugins: [vue(), tailwindcss(), Inspect()],
  resolve: {
    alias: {
      '@': resolve(__dirname, 'src'),
      '@frog/styles': resolve(__dirname, './packages/styles'),
      '@frog/common-ui': resolve(__dirname, './packages/common-ui'),
      '@frog/utils': resolve(__dirname, './packages/utils'),
      '@frog/hooks': resolve(__dirname, './packages/hooks'),
      '@frog/icons': resolve(__dirname, './packages/icons'),
    },
  },
});
