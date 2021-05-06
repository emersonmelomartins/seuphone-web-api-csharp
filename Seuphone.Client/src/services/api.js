import axios from 'axios';

const api = axios.create({
  // baseURL: 'https://localhost:44361/api' // local
  baseURL: 'http://api.emersonmelomartins.dev.br/api' // cloud
  
})

export default api;