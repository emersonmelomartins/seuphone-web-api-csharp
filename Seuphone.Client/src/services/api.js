import axios from 'axios';

const api = axios.create({
  // baseURL: 'https://localhost:44361/api' // local
  baseURL: 'http://api.emersonmelomartins.dev.br/api' // cloud
  
})


api.interceptors.request.use(async (config) => {
  const token = localStorage.getItem("@Seuphone::token");
  if (token) {
    config.headers.Authorization = `Bearer ${token}`;
  }
  return config;
});

api.interceptors.response.use(async (config) => {
  return config;
});

export default api;