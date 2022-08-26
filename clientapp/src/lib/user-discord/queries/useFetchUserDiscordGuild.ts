import axios, { AxiosError } from 'axios';
import { useQuery } from 'react-query';
import { UserGuildMemberDto } from '../models/userGuildMemberDto';

export const useFetchUserDiscordGuild = (guildId: string) => {
  return useQuery<UserGuildMemberDto, AxiosError>(["userDiscordGuilds", guildId] , () => 
    axios.get(`/UserDiscord/Guilds/${guildId}`).then(r => r.data)
  )
}