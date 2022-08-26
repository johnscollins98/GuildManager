import axios, { AxiosError } from 'axios';
import { useQuery } from 'react-query';
import { UserDto } from '../models/userDto';

export const useFetchUserData = () => {
  return useQuery<UserDto, AxiosError>('user', () => {
    return axios.get('/Auth').then(r => r.data);
  }, {
    cacheTime: 1000
  })
}