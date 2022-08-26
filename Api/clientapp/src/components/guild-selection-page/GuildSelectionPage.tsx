import { FC } from 'react';
import { useFetchUserData } from '../../lib/user/queries/useFetchUserData';
import UserGuildsList from './UserGuildsList';

interface GuildSelectionPageProps {}

const GuildSelectionPage: FC<GuildSelectionPageProps> = () => {
  const { data: userData } = useFetchUserData();
  
  return (
    <div className="guild-selection-page">
      <h4 className="mb-3">
        Welcome to Guild Manager, {userData?.name}. Please select a guild to
        manage.
      </h4>
      <p>Note that only servers with the M.O.X bot will appear!</p>
      <UserGuildsList />
    </div>
  );
};

export default GuildSelectionPage;
