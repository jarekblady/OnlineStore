import { baseURL } from "./baseURL";

export default function RemoveProductFromCart(productId, count = 1) {
    return fetch(baseURL + `cart/RemoveProduct?productId=${productId}&count=${count}`, {
        method: "DELETE",
        'credentials': 'include',
    })
        .then(res => res.json())
}