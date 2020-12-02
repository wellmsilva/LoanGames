import Http from './http';
import { getToken } from './utils';


export function obtemTodos() {
    const token = getToken();
    return Http.get('/api/loan', {
        headers: {
            'Authorization': `Bearer ${token}`
        }
    });
}

export function devolve(model) {
    const token = getToken()
    return Http.post('/api/loan/devolve', model, {
        headers: {
            'Authorization': `Bearer ${token}`
        }
    });
}
export function empresta(model) {
    const token = getToken()
    return Http.post('/api/loan/empresta', model, {
        headers: {
            'Authorization': `Bearer ${token}`
        }
    });
}
