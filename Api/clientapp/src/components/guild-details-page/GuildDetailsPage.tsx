import { FC } from 'react';
import { useParams } from 'react-router-dom';
import { useFetchUserDiscordGuild } from '../../lib/user-discord/queries/useFetchUserDiscordGuild';
import ErrorDisplay from '../common/ErrorDisplay';
import Loader from '../common/Loader';

interface GuildDetailsPageProps {}

const GuildDetailsPage: FC<GuildDetailsPageProps> = () => {
  const { guildId } = useParams();
  if (!guildId) throw Error('Guild ID not found');

  const { data: guild, error, isLoading } = useFetchUserDiscordGuild(guildId);

  if (error) return <ErrorDisplay error={error} />;
  if (isLoading || !guild) return <Loader />;

  return (
    <table className="table">
      <thead>
        <tr>
          <th>Nickname</th>
          <th>Roles</th>
          <th>Join Date</th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <td>{guild.nick}</td>
          <td>{guild.roles.join(',')}</td>
          <td>{new Date(guild.joinedAt).toLocaleDateString()}</td>
        </tr>
      </tbody>
    </table>
  );
};

export default GuildDetailsPage;
