import { FC } from 'react';
import { Route, Routes, useLocation } from 'react-router-dom';
import { useFetchUserData } from '../lib/user/queries/useFetchUserData';
import './App.scss';
import ErrorDisplay from './common/ErrorDisplay';
import SuccessDisplay from './common/SuccessDisplay';
import GuildConfigPage from './guild-config-page/GuildConfigPage';
import GuildDetailsPage from './guild-details-page/GuildDetailsPage';
import GuildSelectionPage from './guild-selection-page/GuildSelectionPage';
import Header from './header/Header';

const App: FC = () => {
  const { data: userData } = useFetchUserData();
  const location = useLocation();
  const locationState = (location?.state ?? {}) as {
    success?: string;
    error?: string;
  };

  return (
    <div className="container app">
      <Header />
      <div className="main mt-2 mb-2">
        {locationState.success && (
          <SuccessDisplay message={locationState.success} />
        )}
        {locationState.error && <ErrorDisplay error={locationState.error} />}
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
