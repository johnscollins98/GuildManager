import { FC, useState } from 'react';
import { LogEntryDto } from '../../../lib/guild/model/logEntryDto';
import { FaDiscord } from 'react-icons/fa'
import { ReactComponent as Gw2Icon } from '../../../assets/gw2-icon.svg';

interface LogEntryProps {
  entry: LogEntryDto;
}

const LogEntry: FC<LogEntryProps> = ({ entry }) => {
  const [showDetails, setShowDetails] = useState(false);
  return (
    <div className="border rounded-md p-3 dark:border-0 dark:bg-slate-500">
      <div className="flex justify-between">
        <h3 className="font-bold text-lg">{entry.headline}</h3>
        {entry.sourceApplication === 'Discord' 
          ? <FaDiscord height={20} width={20} /> 
          : <Gw2Icon height={20} width={20} />}
      </div>
      <p className='text-sm'>{new Date(entry.time).toLocaleDateString()}</p>

      {entry.actions && (
        <>
          <p
            className="hover:cursor-pointer hover:text-slate-500 dark:hover:text-gray-300 underline mt-2"
            onClick={() => setShowDetails(!showDetails)}
          >
            {showDetails ? 'Hide Details' : 'Show Details'}
          </p>
          {showDetails && (
            <ul className='list-disc list-inside'>
              {entry.actions.map((action) => (
                <li className='list-disc'>{action}</li>
              ))}
            </ul>
          )}
        </>
      )}
    </div>
  );
};

export default LogEntry;
