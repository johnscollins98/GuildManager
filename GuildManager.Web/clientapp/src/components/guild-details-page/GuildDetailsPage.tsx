import { FC } from 'react';
import { Link, useParams } from 'react-router-dom';
import { useFetchGuildMembers } from '../../lib/discord-guild/queries/useFetchGuildMembers';
import ErrorDisplay from '../common/ErrorDisplay';
import Loader from '../common/Loader';
import { IoMdSettings } from 'react-icons/io';
import { Button } from '../common/Button';

interface GuildDetailsPageProps {}

const GuildDetailsPage: FC<GuildDetailsPageProps> = () => {
  const { guildId } = useParams();
  if (!guildId) throw Error('Guild ID not found');

  const { data: members, error, isLoading } = useFetchGuildMembers(guildId);

  if (error) return <ErrorDisplay error={error} />;
  if (isLoading || !members) return <Loader />;

  return (
    <>
      <Link to={`/${guildId}/config`}>
        <Button>
          <IoMdSettings size={20} className="hover:bg mr-2" />
          Configure
        </Button>
      </Link>
      <div className="flex flex-wrap overflow-auto mt-3 gap-3">
        {members.map(member => (
          <Link to='#' key={member.user.username} className='border rounded-md p-3 flex-basis-1/4 flex-1 hover:bg-slate-100 dark:border-0 dark:bg-slate-500 hover:dark:bg-slate-400 transition-colors ease-in-out duration-150'>
            <h2 className='text-lg font-bold'>{member.user.username}</h2>
            <p className='text-xs'>{member.nick}</p>
            <p className='whitespace-nowrap text-sm'>Joined: {new Date(member.joinedAt).toLocaleDateString()}</p>
          </Link>
        ))}
      </div>
    </>
  );
};

export default GuildDetailsPage;
