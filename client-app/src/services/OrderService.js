export function addOrder(token) {
    return fetch(`/api/order`, {
        method: "POST",
        'credentials': 'include',
        headers: {
            'Authorization': 'Bearer ' + token,
            'Content-Type': 'application/json'
        },
    })
        .then(res => res.json())
}

export function getOrders(token) {
    return fetch(`/api/order`, {
        method: "GET",
        headers: {
            'Authorization': 'Bearer ' + token,
            'Content-Type': 'application/json'
        },
    })
        .then(res => res.json())
}

export function getOrdersForUser(token) {
    return fetch(`/api/order/ordersForUser`, {
        method: "GET",
        headers: {
            'Authorization': 'Bearer ' + token,
            'Content-Type': 'application/json'
        },
    })
        .then(res => res.json())
}

export function updateOrderStatus(id, orderStatus, token) {
    return fetch(`/api/order/${id}/orderStatus?orderStatus=${orderStatus}`, {
        method: 'PUT',
        headers: {
            'Authorization': 'Bearer ' + token
        }
    })
        .then(res => res.json())

}