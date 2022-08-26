import { AxiosError } from 'axios';
import { FC } from 'react';

interface ErrorProps {
  error: AxiosError
}
 
const ErrorDisplay: FC<ErrorProps> = ({ error }) => {
  return (<div className='alert alert-danger'>
    {error.code === '404' ? (
      "Requested resource does not exist"
    ) : (
      "An unknown error occurred. If the issue persists please contact an administrator."
    )}
  </div>);
}
 
export default ErrorDisplay;