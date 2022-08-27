import axios, { AxiosError } from 'axios';
import { useMutation, useQueryClient } from 'react-query';
import { useNavigate } from 'react-router-dom';
import { GuildConfigDetailDto } from '../models/guildConfigDetailDto';

export const useUpdateGuildConfig = (guildId: string) => {
  const navigate = useNavigate();
  const queryClient = useQueryClient();

  return useMutation<void, AxiosError, GuildConfigDetailDto>((guildInfo: GuildConfigDetailDto) => {
    return axios.put(`/GuildConfiguration/${guildId}`, guildInfo);
  }, {
    onSuccess(_data, _variables, _context) {
      navigate(`/${guildId}`, { state: { success: 'Successfully updated Guild Configuration!' } });
      queryClient.invalidateQueries(['guildConfig', guildId]);
    },
    onError(err) {
      navigate(`/${guildId}`, { state: { error: 'Failed to update Guild Configuration.' }});
    }
  })
}