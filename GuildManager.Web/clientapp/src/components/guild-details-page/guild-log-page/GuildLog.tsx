import { FC } from 'react';
import { LogEntryDto } from '../../../lib/guild/model/logEntryDto';
import LogEntry from './LogEntry';

interface GuildLogProps {
  logEntries: LogEntryDto[]
}
 
const GuildLog: FC<GuildLogProps> = ({ logEntries }) => {
  return <div className="flex flex-col gap-3">
    {logEntries.map(logEntry => (
      <LogEntry entry={logEntry} />
    ))}
  </div>;
}
 
export default GuildLog;