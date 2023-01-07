import { baseURL } from "./baseURL";

export default function GetBrands() {
    return fetch(baseURL + `brand`, {
        method: "GET",
    })
        .then(res => res.json())
}