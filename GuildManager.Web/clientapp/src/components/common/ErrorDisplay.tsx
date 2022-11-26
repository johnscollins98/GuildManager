import { AxiosError } from 'axios';
import { FC, HTMLAttributes } from 'react';

interface ErrorProps extends HTMLAttributes<HTMLDivElement> {
  error: AxiosError | string;
}

const ErrorDisplay: FC<ErrorProps> = ({ error, ...props }) => {
  return (
    <div {...props}>
      {typeof error === 'string'
        ? error
        : error.response?.status === 404
        ? 'Requested resource does not exist'
        : error.response?.status === 401
        ? 'You are not logged in and cannot view this content!'
        : error.response?.status === 403
        ? 'You do not have permissions to view this content!'
        : 'An error occurred. If the issue persists please contact an administrator.'}
    </div>
  );
};

export default ErrorDisplay;
