import { FC } from 'react';
import { useNavigate } from 'react-router-dom';
import { useFetchUserDiscordGuilds } from '../../lib/user-discord/queries/useFetchUserDiscordGuilds';
import ErrorDisplay from '../common/ErrorDisplay';
import Loader from '../common/Loader';
import UserGuildCard from './UserGuildCard';
import './UserGuildList.scss';

interface UserGuildsTableProps {}

const UserGuildsList: FC<UserGuildsTableProps> = () => {
  const { data: guilds, isLoading, error } = useFetchUserDiscordGuilds();
  const navigate = useNavigate();

  if (isLoading) return <Loader />;
  if (error) return <ErrorDisplay error={error} />;

  return (
    <div className="guild-list">
      {guilds && guilds.map((guild) => <UserGuildCard guild={guild} />)}
    </div>
  );
};

export default UserGuildsList;
