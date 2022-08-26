import { FC } from 'react';
import { useFetchUserDiscordGuilds } from '../../lib/user-discord/queries/useFetchUserDiscordGuilds';
import ErrorDisplay from '../common/ErrorDisplay';
import Loader from '../common/Loader';
import GuildCard from './GuildCard';
import './GuildList.scss';

interface GuildListProps {}

const GuildList: FC<GuildListProps> = () => {
  const { data: guilds, isLoading, error } = useFetchUserDiscordGuilds();

  if (isLoading) return <Loader />;
  if (error) return <ErrorDisplay error={error} />;

  return (
    <div className="guild-list">
      {guilds &&
        guilds.map((guild) => <GuildCard guild={guild} key={guild.id} />)}
    </div>
  );
};

export default GuildList;
