import { FC, HTMLAttributes } from 'react';

interface SuccessDisplayProps extends HTMLAttributes<HTMLDivElement> {
  message: string;
}

const SuccessDisplay: FC<SuccessDisplayProps> = ({
  message,
  className,
  ...props
}) => {
  return (
    <div className={`alert alert-success ${className ?? ''}`} {...props}>
      {message}
    </div>
  );
};

export default SuccessDisplay;
