import { FC } from 'react';
import { useFetchUserData } from '../../lib/user/queries/useFetchUserData';
import Loader from '../common/Loader';

interface UserInfoCardProps {}

const UserInfoCard: FC<UserInfoCardProps> = () => {
  const { data, isError, isLoading } = useFetchUserData();
  if (isLoading) return <Loader />;

  const devEndpoint = process.env.REACT_APP_API_ENDPOINT;

  return (
    <>
      {isError && (
        <a href={`${devEndpoint}/Auth/Login`} className="btn btn-primary">
          Login
        </a>
      )}
      {data && (
        <a href={`${devEndpoint}/Auth/Logout`} className="btn btn-danger">
          Hey {data.name}, click to log out!
        </a>
      )}
    </>
  );
};

export default UserInfoCard;
