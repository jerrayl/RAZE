import axios from 'axios';

const api = axios.create({
    baseURL: `https://localhost:5001/api/`,
    headers: {
        'Content-Type': 'application/json',
    },
});

export const setClientId = (clientId) => {
    api.defaults.headers.common['X-CLIENT-ID'] = clientId;
    sessionStorage.setItem('clientId', clientId);
};

export const getBuildings = async () => {
    return (await api.get('buildings')).data;
}

