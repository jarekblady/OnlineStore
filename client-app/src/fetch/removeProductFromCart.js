import { baseURL } from "./baseURL";

export default function RemoveProductFromCart(productId, quantity = 1) {
    return fetch(baseURL + `cart/RemoveProduct?productId=${productId}&quantity=${quantity}`, {
        method: "DELETE",
        'credentials': 'include',
    })
        .then(res => res.json())
}