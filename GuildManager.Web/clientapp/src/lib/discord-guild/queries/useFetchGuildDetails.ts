import axios, { AxiosError } from 'axios';
import { useQuery } from 'react-query';
import { GuildDto } from '../models/guildDto';

export const useFetchGuildDetails = (guildId: string) => {
  return useQuery<GuildDto, AxiosError>(["guild", guildId], () => {
    return axios.get(`/Discord/Guilds/${guildId}`).then(r => r.data);
  })
}