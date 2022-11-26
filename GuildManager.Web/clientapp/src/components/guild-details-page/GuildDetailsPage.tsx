import { FC } from 'react';
import { IoMdSettings } from 'react-icons/io';
import { NavLink, Outlet } from 'react-router-dom';
import { Button } from '../common/Button';

interface GuildDetailsPageProps {}

const GuildDetailsPage: FC<GuildDetailsPageProps> = () => {
  return (
    <>
      <nav className="flex justify-between items-center mb-2">
        <div className="flex items-center gap-4">
          <NavLink className={({ isActive }) => (isActive ? 'font-bold' : '')} to="roster">
            Roster
          </NavLink>
          <NavLink className={({ isActive }) => (isActive ? 'font-bold' : '')} to="log">
            Log
          </NavLink>
          <NavLink className={({ isActive }) => (isActive ? 'font-bold' : '')} to="events">
            Events
          </NavLink>
        </div>
        <NavLink to={`config`}>
          <Button>
            <IoMdSettings size={20} className="hover:bg mr-2" />
            Configure
          </Button>
        </NavLink>
      </nav>
      <Outlet />
    </>
  );
};

export default GuildDetailsPage;
