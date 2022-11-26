import axios, { AxiosError } from 'axios';
import { useQuery } from 'react-query';
import { RoleListDto } from '../models/roleListDto';

export const useFetchGuildRoles = (guildId: string) => {
  return useQuery<RoleListDto[], AxiosError>(["roles", guildId], () => {
    return axios.get(`/Discord/Guilds/${guildId}/Roles`).then(r => r.data);
  });
}