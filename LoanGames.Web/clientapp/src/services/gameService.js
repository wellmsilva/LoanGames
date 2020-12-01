import Http from './http';
import { getToken } from './utils';


export function obtemTodos() {

    const token = getToken()
    return Http.get('/api/game', {
        headers: {
            'Authorization': `Bearer ${token}`
        }
    });
}


export function cadastraGame(model) {
    const token = getToken()
    return Http.post('/api/Game', model, {
        headers: {
            'Authorization': `Bearer ${token}`
        }
    });
}

export function editaGame(model) {
    const token = getToken()
    return Http.put('/api/Game', model, {
        headers: {
            'Authorization': `Bearer ${token}`
        }
    });
}
export function exclueGame(id) {
    const token = getToken()
    return Http.post(`/api/Game/${id}/delete`, null,{
        headers: {
            'Authorization': `Bearer ${token}`
        }
    });
}
