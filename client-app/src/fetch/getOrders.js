import { baseURL } from "./baseURL";

export default function GetOrders(token) {
    return fetch(baseURL + `order`, {
        method: "GET",
        headers: {
            'Authorization': 'Bearer ' + token,
            'Content-Type': 'application/json'
        },
    })
        .then(res => res.json())
}