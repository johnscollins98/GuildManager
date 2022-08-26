import { AxiosError } from 'axios';
import { FC } from 'react';

interface ErrorProps {
  error: AxiosError;
}

const ErrorDisplay: FC<ErrorProps> = ({ error }) => {
  return (
    <div className="alert alert-danger">
      {error.response?.status === 404
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
