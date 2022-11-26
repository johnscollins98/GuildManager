import { FC } from 'react';
import { GuildMemberDto } from '../../../lib/discord-guild/models/guildMemberDto';
import MemberCard from './MemberCard';

interface GuildRosterProps {
  members: GuildMemberDto[];
}

const GuildRoster: FC<GuildRosterProps> = ({ members }) => {
  return (
    <div className="flex flex-wrap overflow-auto mt-3 gap-3">
      {members.map((member) => (
        <MemberCard member={member} />
      ))}
    </div>
  );
};

export default GuildRoster;
