import axios, { AxiosError } from 'axios';
import { useQuery } from 'react-query';
import { UserGuildListDto } from '../models/userGuildListDto';

export const useFetchUserDiscordGuilds = () => {
  return useQuery<UserGuildListDto[], AxiosError>("userDiscordGuilds", () => 
    axios.get('/UserDiscord/Guilds').then(r => r.data)
  )
}