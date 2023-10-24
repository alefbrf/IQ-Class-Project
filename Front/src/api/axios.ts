import { API_BASE_URL } from "../constants/api";
import axios from 'axios';

let api =  axios.create({
    baseURL: API_BASE_URL,
    headers: {
        'Access-Control-Allow-Origin': '*',
        'Content-Type': 'application/json',
        'Access-Control-Allow-Methods':'GET,PUT,POST,DELETE,PATCH,OPTIONS'
    }
});

api.interceptors.response.use((response) => response, (error) => {
    console.clear();
    const ERROR_RESPONSE = {
        status: error.response.status,
        message: error.response.data
    }
    return Promise.reject(ERROR_RESPONSE);
});

export default api;