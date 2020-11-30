export function getToken() {
    return JSON.parse(sessionStorage.getItem("token"));
}
export function getUserId() {
    var user = JSON.parse(sessionStorage.getItem("user"));
    return user.id
}

export function getUser() {
    return JSON.parse(sessionStorage.getItem("user"));
}
export function setUser(model) {
    sessionStorage.setItem("user", JSON.stringify(model));
    sessionStorage.setItem("token", JSON.stringify(model.token));
}
export function logOut() {
    sessionStorage.removeItem("user");
    sessionStorage.removeItem("token");
}
