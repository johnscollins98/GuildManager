export interface GuildMemberDto {
  nick: string;
  joinedAt: string;
  user: {
    username: string;
  }
}