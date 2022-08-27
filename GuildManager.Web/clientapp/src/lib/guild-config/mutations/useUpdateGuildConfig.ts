import axios, { AxiosError } from 'axios';
import toast from 'react-hot-toast';
import { useMutation, useQueryClient } from 'react-query';
import { useNavigate } from 'react-router-dom';
import { GuildConfigDetailDto } from '../models/guildConfigDetailDto';

export const useUpdateGuildConfig = (guildId: string) => {
  const navigate = useNavigate();
  const queryClient = useQueryClient();

  return useMutation<void, AxiosError, GuildConfigDetailDto>(
    (guildInfo: GuildConfigDetailDto) => {
      return axios.put(`/GuildConfiguration/${guildId}`, guildInfo);
    },
    {
      onSuccess(_data, _variables, _context) {
        toast.success('Successfully updated Guild Configuration!');
        queryClient.invalidateQueries(['guildConfig', guildId]);
      },
      onError(err) {
        toast.error(`Failed to update Guild Configuration: ${err.message}`);
      },
      onSettled() {
        navigate(`/${guildId}`);
      },
    }
  );
};
