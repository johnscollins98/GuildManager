import axios, { AxiosError } from 'axios';
import { useQuery } from 'react-query';
import { UserDto } from '../models/userDto';

export const useFetchUserData = () => {
  return useQuery<UserDto, AxiosError>(
    'user',
    () => {
      return axios
        .get('/Auth', { validateStatus: (s) => s < 500 })
        .then((r) => (r.status === 200 ? r.data : null));
    },
    {
      cacheTime: 1000,
    }
  );
};
