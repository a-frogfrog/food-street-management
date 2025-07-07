import { resolve } from "path";

const aliases = {
  "@": resolve(__dirname, "./src"),
  "@frog/*": resolve(__dirname, "./packages/*"),
  "@frog/components": resolve(__dirname, "./packages/components"),
  "@frog/utils": resolve(__dirname, "./packages/utils"),
  "@frog/hooks": resolve(__dirname, "./packages/hooks"),
  "@frog/constants": resolve(__dirname, "./packages/constants"),
  "@frog/directives": resolve(__dirname, "./packages/directives"),
  "@frog/event": resolve(__dirname, "./packages/event"),
  "@frog/request": resolve(__dirname, "./packages/request"),
};

export const viteAliases = aliases;

export const tsAliases = Object.fromEntries(
  Object.entries(aliases).map(([key, value]) => [
    `${key}/*`,
    [value.replace(__dirname + "/", "") + "/*"],
  ]),
);
