import axios from 'axios';
import {Login,Register} from '../Types/UserTypes';

const api = axios.create({
  baseURL: 'http://localhost:5109/api/User', // Your API base URL
  headers: {
    'Content-Type': 'application/json',
  },
});

const authService = {
  register: async (userData:Register) => {
    const response = await api.post('/register', userData);
    return response.data;
  },

  login: async (credentials:Login) => {
    const response = await api.post('/login', credentials);
    console.log(response);
    if (response.data.success) {
        return response.data.data; 
    }else {
        throw new Error(response.data.message || 'Login failed');
    }
  },
};

export default authService;