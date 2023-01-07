import { baseURL } from "./baseURL";

export default function AddOrder(token) {
    return fetch(baseURL + `order`, {
        method: "POST",
        'credentials': 'include',
        headers: {
            'Authorization': 'Bearer ' + token,
            'Content-Type': 'application/json'
        },
    })
        .then(res => res.json())
}