import { fileURLToPath, URL } from "node:url";

import { defineConfig } from "vite";
import vue from "@vitejs/plugin-vue";

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [vue()],
  resolve: {
    alias: {
      "@": fileURLToPath(new URL("./src", import.meta.url)),
    },
  },
  server: {
    proxy: {
      "/search": {
        target: "https://localhost:7180/api/movie",
        changeOrigin: true,
        secure: false,
        rewrite: (path) => path.replace(/^\/search/, ""),
      },
      "/detail": {
        target: "https://localhost:7180/api/movie/detail",
        changeOrigin: true,
        secure: false,
        rewrite: (path) => path.replace(/^\/detail/, ""),
      },
    },
  },
});
