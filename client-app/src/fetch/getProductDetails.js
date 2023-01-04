import { baseURL } from "./baseURL";

export default function GetProductDetails(productId) {
    return fetch(baseURL +`product/${productId}`, {
        method: "GET"
    })
        .then(res => res.json())
}