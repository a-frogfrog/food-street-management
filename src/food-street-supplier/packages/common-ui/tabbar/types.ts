import type { Component } from 'vue';

export interface TabBarProps {
  /**
   * The items to display in the tab bar.
   */  
  items: TabBarItemProps[];

  /**
   * Whether to use the router for navigation.
   */
  router?: boolean;

  color?: string;
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
  /**
   * The cover image to display in the tab bar item.
   * icon and label will be hidden when cover is provided.
   */
  cover?: string;
}

export type TabBarEmits = {
  /**
   * Emitted when the tab bar item is clicked.
   */
  tabBarItemClick:[string]
};
