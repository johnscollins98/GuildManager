import { FC } from 'react';
import { LogEntryDto } from '../../../lib/guild/model/logEntryDto';
import GuildLog from './GuildLog';

interface GuildLogPageProps {
  
}
 
const mockLog: LogEntryDto[] = [
  { headline: 'Mock Entry 1', sourceApplication: 'Guild Wars 2', time: new Date().toISOString() },
  { headline: 'Mock Entry 2', sourceApplication: 'Discord', time: new Date(2022, 1, 1).toISOString(), actions: [
    'sub-action 1',
    'sub-action 2',
  ] },
];

const GuildLogPage: FC<GuildLogPageProps> = () => {
  return <GuildLog logEntries={mockLog} />;
}
 
export default GuildLogPage;