import { FC } from 'react';
import { Link, useLocation, useParams } from 'react-router-dom';
import { useFetchGuildMembers } from '../../lib/discord-guild/queries/useFetchGuildMembers';
import ErrorDisplay from '../common/ErrorDisplay';
import Loader from '../common/Loader';

interface GuildDetailsPageProps {}

const GuildDetailsPage: FC<GuildDetailsPageProps> = () => {
  const { guildId } = useParams();
  const location = useLocation();
  const locationState = (location?.state ?? {}) as { success?: string, error?: string };
  console.log(locationState);
  if (!guildId) throw Error('Guild ID not found');

  const { data: members, error, isLoading } = useFetchGuildMembers(guildId);

  if (error) return <ErrorDisplay error={error} />;
  if (isLoading || !members) return <Loader />;

  return (
    <>
      <Link className="btn btn-primary" to={`/${guildId}/config`}>Configure Guild</Link>
      <table className="table">
        <thead>
          <tr>
            <th>Username</th>
            <th>Nickname</th>
            <th>Join Date</th>
          </tr>
        </thead>
        <tbody>
          {members.map((guildMember) => (
            <tr key={guildMember.user.username}>
              <td>{guildMember.user.username}</td>
              <td>{guildMember.nick}</td>
              <td>{new Date(guildMember.joinedAt).toLocaleDateString()}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </>
  );
};

export default GuildDetailsPage;
