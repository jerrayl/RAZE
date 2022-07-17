import axios from 'axios';

const api = axios.create({
    baseURL: `https://localhost:5001/api/`,
    headers: {
        'Content-Type': 'application/json',
    },
});

export const setSessionId = (sessionId) => {
    api.defaults.headers.common['X-SESSION-ID'] = sessionId;
    sessionStorage.setItem('sessionId', sessionId);
};

export const getBuildings = async () => {
    return (await api.get('buildings')).data;
}

export const login = async (email) => {
    const sessionId = (await api.post('login', {email: email})).data;
    setSessionId(sessionId);
}

