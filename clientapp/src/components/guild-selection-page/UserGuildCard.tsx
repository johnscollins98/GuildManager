import { FC } from 'react';
import { useNavigate } from 'react-router-dom';
import { UserGuildListDto } from '../../lib/user-discord/models/userGuildListDto';
import './UserGuildCard.scss';

interface UserGuildCardProps {
  guild: UserGuildListDto;
}

const UserGuildCard: FC<UserGuildCardProps> = ({ guild }) => {
  const navigate = useNavigate();
  return (
    <div className="card user-guild-card" onClick={() => navigate(`/${guild.id}`)}>
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

export default UserGuildCard;
