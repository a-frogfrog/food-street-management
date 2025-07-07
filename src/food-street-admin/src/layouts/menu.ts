import { useMenuStore } from "@/stores";
import type { PermissionMenuItem } from "@/types";
import { h, ref } from "vue";
import type { ItemType } from "ant-design-vue";

const menuStore = useMenuStore();

export function useMenuData() {
  const menuData = ref<ItemType[]>();

  _getMenuData();
  async function _getMenuData() {
    const response = await menuStore.getMenuList();
    if (response.isSucceed) {
      menuData.value = convertMenuData(response.data);
    }
  }

  return {
    menuData,
    clearMenuList: menuStore.clearMenuList,
  };
}

function convertMenuData(data: PermissionMenuItem[]): ItemType[] {
  return data.map((item) => {
    const baseitem: ItemType = {
      key: item.url,
      title: item.name,
      label: item.name,
      disabled: false,
      icon: renderIcon(item.icon as string),
    };

    return item.children.length > 0
      ? {
          ...baseitem,
          children: convertMenuData(item.children),
        }
      : baseitem;
  });
}

const renderIcon = (icon: string) => {
  return () => h("i", { class: `iconfont ${icon}` });
};
