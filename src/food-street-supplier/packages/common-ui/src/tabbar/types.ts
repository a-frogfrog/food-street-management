import type { Component } from 'vue';



export interface TabBarProps {
  /**
   * The items to display in the tab bar.
   */  
  items: TabBarItemProps[];
}


export interface TabBarItemProps {
  /**
   * The icon to display in the tab bar item.
   */
  icon: string | Component;
  /**
   * The label to display in the tab bar item.
   */
  label: string;

  /**
   * The name of the tab bar item.
   */
  name: string;
}

export type TabBarItemEmits = {
  /**
   * Emitted when the tab bar item is clicked.
   */
  tabBarItemClick: (name: string) => void;
};
