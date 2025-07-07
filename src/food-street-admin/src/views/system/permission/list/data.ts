import { getPermissionList } from "@/api";
import {
  type PermissionItem,
  PermissionStatus,
  type PermissionTypeItem,
} from "@/types";
import { EMPTY } from "@frog/constants";
import { ref } from "vue";

export interface PermissionViewItem {
  id: string;
  label: string;
  icon: string;
  url: string;
  type: PermissionTypeItem;
  status: "正常" | "禁用";
  sort: number;
  description: string;
  children?: PermissionViewItem[];
}

export function useGetPermission() {
  const treeData = ref<PermissionViewItem[]>([]);
  const descriptionData = ref<PermissionViewItem>({
    id: "",
    label: "",
    icon: "",
    url: "",
    type: "菜单权限",
    status: "正常",
    sort: 0,
    description: EMPTY.text,
  });

  async function _getPermissionData() {
    const response = await getPermissionList();
    if (response.isSucceed) {
      treeData.value = convertTreeData(response.data);
      descriptionData.value = treeData.value[0];
    }
  }

  _getPermissionData();

  return {
    treeData,
    descriptionData,
  };
}

function convertTreeData(data: PermissionItem[]): PermissionViewItem[] {
  return data.map((item) => {
    const baseItem: PermissionViewItem = {
      id: item.id,
      label: item.name,
      icon: item.icon,
      url: item.url,
      type: item.type as PermissionTypeItem,
      sort: item.serialNumber,
      status: item.status === PermissionStatus.active ? "正常" : "禁用",
      description: item.description || EMPTY.text,
    };

    return item.children.length > 0
      ? {
          ...baseItem,
          children: convertTreeData(item.children),
        }
      : baseItem;
  });
}
