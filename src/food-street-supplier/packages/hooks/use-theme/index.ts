type ThemeType = 'light' | 'dark' | 'system';
const ThemeKey = '__theme__';

export function useTheme() {
  const currentTheme: ThemeType = getUserTheme() || getSystemTheme();

  return {
    currentTheme,
  };
}

const getUserTheme = () => {
  return localStorage.getItem(ThemeKey) as ThemeType;
};

const getSystemTheme = () => {
  return window.matchMedia('(prefers-color-scheme: dark)').matches
    ? 'dark'
    : 'light';
};
