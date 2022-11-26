import { FC } from 'react';
import { Link } from 'react-router-dom';
import { UserGuildListDto } from '../../lib/user-discord/models/userGuildListDto';

interface GuildCardProps {
  guild: UserGuildListDto;
}

const GuildCard: FC<GuildCardProps> = ({ guild }) => {
  return (
    <Link
      to={`/${guild.id}`}
      className="flex flex-1 p-3 min-w-max items-center rounded-lg bg-slate-50 hover:bg-slate-100 border dark:border-0 hover:dark:bg-slate-400 dark:bg-slate-500 transition-colors ease-in-out duration-150"
    >
      <img
        src={`https://cdn.discordapp.com/icons/${guild.id}/${guild.icon}.png`}
        alt="guild-icon"
      />
      <h3 className="text-xl font-bold ml-8">{guild.name}</h3>
    </Link>
  );
};

export default GuildCard;
