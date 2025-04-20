import axios from 'axios';

const api = axios.create({
  baseURL: 'http://localhost:3000/api', // ez az express backend
});

export default api;
