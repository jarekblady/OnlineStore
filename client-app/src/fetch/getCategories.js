import { baseURL } from "./baseURL";

export default function GetCategories() {
    return fetch(baseURL + `category`, {
        method: "GET",
    })
        .then(res => res.json())
}