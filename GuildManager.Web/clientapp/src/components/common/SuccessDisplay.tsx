import { FC, HTMLAttributes } from 'react';

interface SuccessDisplayProps extends HTMLAttributes<HTMLDivElement> {
  message: string;
}

const SuccessDisplay: FC<SuccessDisplayProps> = ({
  message,
  ...props
}) => {
  return (
    <div {...props}>
      {message}
    </div>
  );
};

export default SuccessDisplay;
