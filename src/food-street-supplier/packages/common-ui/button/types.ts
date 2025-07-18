export interface ButtonProps {
  type?: 'primary' | 'danger' | 'warning' | 'success';
  disabled?: boolean;
  size?: 'small' | 'medium' | 'large';
  round?: boolean;
  color?: string;
}

export type ButtonEmits = {
  click: [];
};
