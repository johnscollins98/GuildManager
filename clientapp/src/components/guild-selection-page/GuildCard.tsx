import { FC } from 'react';
import { useNavigate } from 'react-router-dom';
import { UserGuildListDto } from '../../lib/user-discord/models/userGuildListDto';
import './GuildCard.scss';

interface GuildCardProps {
  guild: UserGuildListDto;
}

const GuildCard: FC<GuildCardProps> = ({ guild }) => {
  const navigate = useNavigate();
  return (
    <div className="card guild-card" onClick={() => navigate(`/${guild.id}`)}>
      <div className="card-body">
        <img
          src={`https://cdn.discordapp.com/icons/${guild.id}/${guild.icon}.png`}
          alt="guild-icon"
        />
        <h4>{guild.name}</h4>
      </div>
    </div>
  );
};

export default GuildCard;
