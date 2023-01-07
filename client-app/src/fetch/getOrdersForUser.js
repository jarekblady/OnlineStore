import { baseURL } from "./baseURL";

export default function GetOrdersForUser(token) {
    return fetch(baseURL + `order/ordersForUser`, {
        method: "GET",
        headers: {
            'Authorization': 'Bearer ' + token,
            'Content-Type': 'application/json'
        },
    })
        .then(res => res.json())
}