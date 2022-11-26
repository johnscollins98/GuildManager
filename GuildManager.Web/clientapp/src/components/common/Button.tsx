import { ButtonHTMLAttributes, FC } from 'react';

export interface ButtonProps extends ButtonHTMLAttributes<HTMLButtonElement> {
  className?: string;
}

export const Button: FC<ButtonProps> = ({ className, ...props }) => {
  return (
    <button
      className={`py-2 px-3 bg-slate-600 text-white hover:bg-slate-500 rounded-lg transition-colors ease-in-out duration-150 flex justify-center items-center ${className}`}
      {...props}
    />
  );
};
