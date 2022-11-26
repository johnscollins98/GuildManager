import { FC } from 'react';
import { Link } from 'react-router-dom';
import { GuildMemberDto } from '../../../lib/discord-guild/models/guildMemberDto';

interface MemberCardProps {
  member: GuildMemberDto;
}

const MemberCard: FC<MemberCardProps> = ({ member }) => {
  return (
    <Link
      to="#"
      key={member.user.username}
      className="border rounded-md p-3 flex-basis-1/4 flex-1 hover:bg-slate-100 dark:border-0 dark:bg-slate-500 hover:dark:bg-slate-400 transition-colors ease-in-out duration-150"
    >
      <h3 className="text-lg font-bold">{member.user.username}</h3>
      <p className="text-xs">{member.nick}</p>
      <p className="whitespace-nowrap text-sm">
        Joined: {new Date(member.joinedAt).toLocaleDateString()}
      </p>
    </Link>
  );
};

export default MemberCard;
