import { FC } from 'react';
import { useParams } from 'react-router-dom';
import { useFetchGuildMembers } from '../../../lib/discord-guild/queries/useFetchGuildMembers';
import ErrorDisplay from '../../common/ErrorDisplay';
import Loader from '../../common/Loader';
import GuildRoster from './GuildRoster';

interface GuildRosterPageProps {}

const GuildRosterPage: FC<GuildRosterPageProps> = () => {
  const { guildId } = useParams();
  if (!guildId) throw Error('Guild ID not found');

  const { data: members, error, isLoading } = useFetchGuildMembers(guildId);

  if (error) return <ErrorDisplay error={error} />;
  if (isLoading || !members) return <Loader />;
  
  return <GuildRoster members={members} />;
};

export default GuildRosterPage;
