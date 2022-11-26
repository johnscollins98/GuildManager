import { FC, InputHTMLAttributes } from 'react';

export interface InputProps extends InputHTMLAttributes<HTMLInputElement> {
  className?: string;
}

export const Input: FC<InputProps> = ({ className, ...props }) => {
  return (
    <input
      className={`p-3 flex-1 rounded-lg dark:bg-slate-700 bg-slate-200 focus-visible:outline-none ${className}`}
      {...props}
    />
  );
};
