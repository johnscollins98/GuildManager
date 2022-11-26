import { FC } from 'react';
import { IoMdSettings } from 'react-icons/io';
import { NavLink, Outlet, useParams } from 'react-router-dom';
import { useFetchGuildDetails } from '../../lib/discord-guild/queries/useFetchGuildDetails';
import { Button } from '../common/Button';
import ErrorDisplay from '../common/ErrorDisplay';
import Loader from '../common/Loader';

interface GuildDetailsPageProps {}

const GuildDetailsPage: FC<GuildDetailsPageProps> = () => {
  const { guildId } = useParams();
  const { data: guild, isLoading, isError, error } = useFetchGuildDetails(guildId!);

  if (isError && error) {
    return <ErrorDisplay error={error} />;
  }

  if (isLoading || !guild) {
    return <Loader />;
  }

  return (
    <>
      <div className='flex items-center mt-3 mb-1'>
        <img
          src={`https://cdn.discordapp.com/icons/${guild.id}/${guild.icon}.png`}
          alt="guild-icon"
          width={32}
          height={32}
        />
        <h2 className="text-2xl font-bold ml-3">{guild.name}</h2>
      </div>
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
