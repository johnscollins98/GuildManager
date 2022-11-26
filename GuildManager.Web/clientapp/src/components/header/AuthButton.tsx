import { FC } from 'react';
import { useFetchUserData } from '../../lib/user/queries/useFetchUserData';
import { Button } from '../common/Button';
import Loader from '../common/Loader';

interface AuthButtonProps {}

const AuthButton: FC<AuthButtonProps> = () => {
  const { data, isLoading } = useFetchUserData();
  if (isLoading) return <Loader />;

  const devEndpoint = process.env.REACT_APP_API_ENDPOINT ?? '';

  return (
    <>
      {!data && (
        <a href={`${devEndpoint}/Auth/Login`}>
          <Button>Login</Button>
        </a>
      )}
      {data && (
        <a href={`${devEndpoint}/Auth/Logout`}>
          <Button>Logout</Button>
        </a>
      )}
    </>
  );
};

export default AuthButton;
