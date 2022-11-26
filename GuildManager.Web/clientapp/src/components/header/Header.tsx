import { FC, useCallback } from 'react';
import { Link } from 'react-router-dom';
import AuthButton from './AuthButton';
import { BsFillMoonStarsFill } from 'react-icons/bs';

interface HeaderProps {
  darkTheme: boolean;
  setDarkTheme: (newValue: boolean) => void;
}

const Header: FC<HeaderProps> = ({ darkTheme, setDarkTheme }) => {
  const toggleDarkMode = useCallback(() => {
    setDarkTheme(!darkTheme);
  }, [darkTheme, setDarkTheme])

  return (
    <div className="flex justify-between items-center">
      <Link to="/" className="text-4xl font-bold">
        Guild Manager
      </Link>
      <div className='flex items-center gap-4'>
        <BsFillMoonStarsFill onClick={toggleDarkMode} size={24} />
        <AuthButton />
      </div>
    </div>
  );
};

export default Header;
