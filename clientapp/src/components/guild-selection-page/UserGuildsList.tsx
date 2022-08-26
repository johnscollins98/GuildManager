import { FC } from 'react';
import { useNavigate } from 'react-router-dom';
import { useFetchUserDiscordGuilds } from '../../lib/user-discord/queries/useFetchUserDiscordGuilds';
import ErrorDisplay from '../common/ErrorDisplay';
import Loader from '../common/Loader';
import './UserGuildList.scss';

interface UserGuildsTableProps {}

const UserGuildsList: FC<UserGuildsTableProps> = () => {
  const { data: guilds, isLoading, error } = useFetchUserDiscordGuilds();
  const navigate = useNavigate();

  if (isLoading) return <Loader />;
  if (error) return <ErrorDisplay error={error} />;

  return (
    <table className="table table-hover user-guilds-list">
      <thead>
        <tr>
          <th>Guild ID</th>
          <th>Guild Name</th>
          <th>Is Owner?</th>
        </tr>
      </thead>
      <tbody>
        {guilds &&
          guilds.map((guild) => (
            <tr key={guild.id} onClick={() => navigate(`/${guild.id}`)}>
              <td>{guild.id}</td>
              <td>{guild.name}</td>
              <td>{guild.owner ? 'true' : 'false'}</td>
            </tr>
          ))}
      </tbody>
    </table>
  );
};

export default UserGuildsList;
