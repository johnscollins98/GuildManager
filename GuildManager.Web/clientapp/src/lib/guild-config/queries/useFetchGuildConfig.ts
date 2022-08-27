import axios, { AxiosError } from 'axios';
import { useQuery } from 'react-query';
import { GuildConfigDetailDto } from '../models/guildConfigDetailDto';

export const useFetchGuildConfig = (guildId: string) => {
  return useQuery<GuildConfigDetailDto, AxiosError>(
    ['guildConfig', guildId],
    () => {
      return axios.get(`/GuildConfiguration/${guildId}`).then((r) => r.data);
    }
  );
};
