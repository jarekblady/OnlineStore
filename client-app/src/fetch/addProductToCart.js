import { baseURL } from "./baseURL";

export default function AddProductToCart(productId, count = 1) {
    return fetch(baseURL + `cart/AddProduct?productId=${productId}&count=${count}`, {
        method: "POST",
        'credentials': 'include',
    })
        .then(res => res.json())
}