import { baseURL } from "./baseURL";

export default function GetCart() {
    return fetch(baseURL + `cart`, {
        method: "GET",
        'credentials': 'include',
    })
        .then(res => res.json())
}