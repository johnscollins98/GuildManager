import { FC } from 'react';
import { useNavigate } from 'react-router-dom';
import './Header.scss';
import UserInfoCard from './UserInfoCard';

interface HeaderProps {}

const Header: FC<HeaderProps> = () => {
  const navigate = useNavigate();
  return (
    <div className="header mt-2 mb-2">
      <h1 onClick={() => navigate('/')}>Guild Manager</h1>
      <div className="actions">
        <UserInfoCard />
      </div>
    </div>
  );
};

export default Header;
