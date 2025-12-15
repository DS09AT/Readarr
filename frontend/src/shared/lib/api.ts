import axios from 'axios';

// Create instance immediately but base URL will be dynamic
const api = axios.create({
  headers: {
    'Content-Type': 'application/json',
  },
});

// Request interceptor to set URL and Key dynamically from window.Shelvance
api.interceptors.request.use((config) => {
  config.baseURL = window.Shelvance?.apiRoot || '/api/v1';
  
  if (window.Shelvance?.apiKey) {
    config.headers['X-Api-Key'] = window.Shelvance.apiKey;
  }
  
  return config;
});

api.interceptors.response.use(
  (response) => response,
  (error) => {
    return Promise.reject(error);
  }
);

export default api;