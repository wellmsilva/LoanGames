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
