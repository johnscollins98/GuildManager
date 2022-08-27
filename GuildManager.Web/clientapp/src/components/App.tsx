import { FC } from 'react';
import { Toaster } from 'react-hot-toast';
import { Route, Routes } from 'react-router-dom';
import { useFetchUserData } from '../lib/user/queries/useFetchUserData';
import './App.scss';
import GuildConfigPage from './guild-config-page/GuildConfigPage';
import GuildDetailsPage from './guild-details-page/GuildDetailsPage';
import GuildSelectionPage from './guild-selection-page/GuildSelectionPage';
import Header from './header/Header';

const App: FC = () => {
  const { data: userData } = useFetchUserData();

  return (
    <div className="container app">
      <Header />
      <Toaster />
      <div className="main mt-2 mb-2">
        {!userData && <h4>Please login to Guild Manager to get started!</h4>}
        {userData && (
          <Routes>
            <Route path="/" element={<GuildSelectionPage />}></Route>
            <Route path="/:guildId" element={<GuildDetailsPage />}></Route>
            <Route
              path="/:guildId/config"
              element={<GuildConfigPage />}
            ></Route>
          </Routes>
        )}
      </div>
    </div>
  );
};

export default App;
