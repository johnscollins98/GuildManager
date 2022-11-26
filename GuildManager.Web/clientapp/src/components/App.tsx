import { FC, useEffect, useState } from 'react';
import { Toaster } from 'react-hot-toast';
import { Navigate, Route, Routes } from 'react-router-dom';
import { useFetchUserData } from '../lib/user/queries/useFetchUserData';
import GuildConfigPage from './guild-config-page/GuildConfigPage';
import GuildDetailsPage from './guild-details-page/GuildDetailsPage';
import GuildEvents from './guild-details-page/GuildEvents';
import GuildLog from './guild-details-page/GuildLog';
import GuildRoster from './guild-details-page/GuildRoster';
import GuildSelectionPage from './guild-selection-page/GuildSelectionPage';
import Header from './header/Header';

const App: FC = () => {
  const { data: userData } = useFetchUserData();
  const [darkTheme, setDarkTheme] = useState(localStorage.getItem('theme') === 'dark');
  useEffect(() => {
    localStorage.setItem('theme', darkTheme ? 'dark' : 'light');
  }, [darkTheme]);

  return (
    <div className={`${darkTheme ? 'dark' : ''}`}>
      <div
        className={`bg-slate-50 dark:bg-slate-800 dark:text-gray-200 text-slate-800 h-screen p-4 flex flex-col gap-3 overflow-hidden`}
      >
        <Header darkTheme={darkTheme} setDarkTheme={setDarkTheme} />
        <Toaster />
        <div className="flex flex-col flex-1 overflow-hidden">
          {!userData && <h2 className="text-lg">Please login to Guild Manager to get started!</h2>}
          {userData && (
            <Routes>
              <Route path="/" element={<GuildSelectionPage />}></Route>
              <Route path="/:guildId" element={<GuildDetailsPage />}>
                <Route index element={<Navigate to='roster' replace />} />
                <Route path="config" element={<GuildConfigPage />} />
                <Route path="roster" element={<GuildRoster />} />
                <Route path="log" element={<GuildLog />} />
                <Route path="events" element={<GuildEvents />} />
              </Route>
            </Routes>
          )}
        </div>
      </div>
    </div>
  );
};

export default App;
