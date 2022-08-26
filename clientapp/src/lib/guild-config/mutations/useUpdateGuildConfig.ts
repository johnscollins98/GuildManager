import axios from 'axios';
import { useMutation } from 'react-query';
import { useNavigate } from 'react-router-dom';
import { GuildConfigDetailDto } from '../models/guildConfigDetailDto';

export const useUpdateGuildConfig = (guildId: string) => {
  const navigate = useNavigate();

  return useMutation((guildInfo: GuildConfigDetailDto) => {
    return axios.put(`/GuildConfiguration/${guildId}`, guildInfo);
  }, {
    onSuccess(_data, _variables, _context) {
      navigate('/');
    },
  })
}