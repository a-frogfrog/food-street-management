import Cookie from "js-cookie";

const key = "__FOOD_STREET_ADMIN_TOKEN__";

/**
 *  Token 管理
 */
export function useToken() {
  function setToken(token: string) {
    Cookie.set(key, token);
  }

  function getToken(): string | undefined {
    return Cookie.get(key);
  }

  function removeToken() {
    Cookie.remove(key);
  }

  return {
    setToken,
    getToken,
    removeToken,
  };
}
