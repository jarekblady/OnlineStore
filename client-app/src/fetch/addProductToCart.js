import { baseURL } from "./baseURL";

export default function AddProductToCart(productId, quantity = 1) {
    return fetch(baseURL + `cart/AddProduct?productId=${productId}&quantity=${quantity}`, {
        method: "POST",
        'credentials': 'include',
    })
        .then(res => res.json())
}