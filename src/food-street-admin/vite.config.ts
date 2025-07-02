import { defineConfig } from "vite";
import vue from "@vitejs/plugin-vue";
import { viteAliases } from "./aliases.config";

import tailwindcss from "@tailwindcss/vite";
import Components from "unplugin-vue-components/vite";
import AutoImport from "unplugin-auto-import/vite";
import {
  AntDesignVueResolver,
  ElementPlusResolver,
} from "unplugin-vue-components/resolvers";

// https://vite.dev/config/
export default defineConfig({
  plugins: [
    vue(),
    tailwindcss(),
    AutoImport({
      resolvers: [ElementPlusResolver()],
    }),
    Components({
      resolvers: [
        AntDesignVueResolver({
          importStyle: false, // css in js
        }),
        ElementPlusResolver(),
      ],
    }),
  ],
  resolve: {
    alias: viteAliases,
  },
});
