import { defineConfig } from 'vite';
import vue from '@vitejs/plugin-vue';
import { resolve } from 'path';
import tailwindcss from '@tailwindcss/vite';
import Inspect from 'vite-plugin-inspect'

// https://vite.dev/config/
export default defineConfig({
  server: {
    host: true,
  },
  plugins: [vue(), tailwindcss(),Inspect()],
  resolve: {
    alias: {
      '@': resolve(__dirname, 'src'),
      '@frog/layouts': resolve(__dirname, './packages/layouts'),
      '@frog/styles': resolve(__dirname, './packages/styles'),
      '@frog/common-ui': resolve(__dirname, './packages/common-ui'),
    },
  },
});
