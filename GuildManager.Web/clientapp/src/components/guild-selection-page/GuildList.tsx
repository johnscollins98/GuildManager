import { FC } from 'react';
import { useFetchUserDiscordGuilds } from '../../lib/user-discord/queries/useFetchUserDiscordGuilds';
import ErrorDisplay from '../common/ErrorDisplay';
import Loader from '../common/Loader';
import GuildCard from './GuildCard';

interface GuildListProps {}

const GuildList: FC<GuildListProps> = () => {
  const { data: guilds, isLoading, error } = useFetchUserDiscordGuilds();

  if (isLoading) return <Loader />;
  if (error) return <ErrorDisplay error={error} />;

  return (
    <div className='flex overflow-y-auto overflow-x-hidden flex-wrap gap-2'>
      {guilds &&
        guilds.map((guild) => <GuildCard guild={guild} key={guild.id} />)}
    </div>
  );
};

export default GuildList;
