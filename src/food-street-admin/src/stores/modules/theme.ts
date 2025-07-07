import { defineStore } from "pinia";
import { theme } from "ant-design-vue";

/**
 * 主题
 */
const ThemeKey = "__theme__";
type ThemeModeType = "light" | "dark";

function changeTheme(t: ThemeModeType) {
  document.documentElement.dataset.theme = t;
  document.documentElement.className = t;
  localStorage.setItem(ThemeKey, t);
}

function initTheme(): ThemeModeType {
  const theme = localStorage.getItem(ThemeKey);
  if (theme) {
    changeTheme(theme as ThemeModeType);
    return theme as ThemeModeType;
  } else {
    // 默认跟随系统
    const systemTheme = window.matchMedia("(prefers-color-scheme: dark)")
      .matches
      ? "dark"
      : "light";
    changeTheme(systemTheme);
    return systemTheme;
  }
}

export const useThemeStore = defineStore("theme", {
  state: () => ({
    theme: initTheme() as ThemeModeType,
    antTheme:
      initTheme() === "dark" ? theme.darkAlgorithm : theme.defaultAlgorithm, // ant design theme
  }),
  getters: {
    isDark: (state) => state.theme === "dark",
  },
  actions: {
    setTheme(theme: ThemeModeType) {
      this.theme = theme;
      changeTheme(theme);
    },
    toggleTheme() {
      if (this.theme === "dark") {
        this.setTheme("light");
      } else {
        this.setTheme("dark");
      }
    },
  },
});
