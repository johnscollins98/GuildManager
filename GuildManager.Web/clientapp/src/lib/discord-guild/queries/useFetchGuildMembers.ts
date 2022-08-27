// TODO - temporary for prototyping.

import axios, { AxiosError } from 'axios';
import { useQuery } from 'react-query';
import { GuildMemberDto } from '../models/guildMemberDto';

export const useFetchGuildMembers = (guildId: string) => {
  return useQuery<GuildMemberDto[], AxiosError>(["guildMembers", guildId], () => {
    return axios.get(`/Discord/Guilds/${guildId}/Members`).then(r => r.data);
  })
}