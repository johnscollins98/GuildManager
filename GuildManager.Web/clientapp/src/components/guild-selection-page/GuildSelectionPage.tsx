import { FC } from 'react';
import { useFetchUserData } from '../../lib/user/queries/useFetchUserData';
import GuildList from './GuildList';

interface GuildSelectionPageProps {}

const GuildSelectionPage: FC<GuildSelectionPageProps> = () => {
  const { data: userData } = useFetchUserData();

  return (
    <div className='flex flex-col flex-1 overflow-hidden'>
      <h2 className='font-bold text-2xl mb-2 text-center'>
        Welcome to Guild Manager, {userData?.name}. Please select a guild to
        manage.
      </h2>
      <p className='text-md text-gray-500 dark:text-gray-400 mb-2 text-center'>Note that only servers with the M.O.X bot will appear!</p>
      <GuildList />
    </div>
  );
};

export default GuildSelectionPage;
