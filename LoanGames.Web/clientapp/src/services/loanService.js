import Http from './http';
import { getToken } from './utils';


export function obtemPessoas() {
    const token = getToken();
    return Http.get('/person', {
        params: {
            'Authentication':  `Bearer ${token}`,
        }
    });
}
