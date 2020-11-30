import Http from './http';
import { getToken } from './utils';


export function obtemPessoas() {

    const token = getToken()
    return Http.get('/api/person', {
        headers: {
            'Authorization': `Bearer ${token}`
        }
    });
}

export function cadastraPessoa(model) {
    const token = getToken()
    return Http.post('/api/person', model, {
        headers: {
            'Authorization': `Bearer ${token}`
        }
    });
}

export function editaPessoa(model) {
    const token = getToken()
    return Http.put('/api/person', model, {
        headers: {
            'Authorization': `Bearer ${token}`
        }
    });
}
export function excluePessoa(id) {
    const token = getToken()
    return Http.delete(`/api/person/${id}`, {
        headers: {
            'Authorization': `Bearer ${token}`
        }
    });
}
