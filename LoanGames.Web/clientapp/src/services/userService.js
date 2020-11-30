import Http from './http';


export function login(model) {
    return Http.post('/api/Account/authenticate', model);
}
