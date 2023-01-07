import { baseURL } from "./baseURL";

export default function UpdateOrderStatus(id, orderStatus, token) {
    return fetch(baseURL + `order/${id}/orderStatus?orderStatus=${orderStatus}`, {
        method: 'PUT',
        headers: {
            'Authorization': 'Bearer ' + token
        }})
        
}