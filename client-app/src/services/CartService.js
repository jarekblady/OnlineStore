export function getCart() {
    return fetch(`/api/cart`, {
        method: "GET",
        'credentials': 'include',
    })
        .then(res => res.json())
}

export function addProductToCart(productId, quantity = 1) {
    return fetch(`/api/cart/AddProduct?productId=${productId}&quantity=${quantity}`, {
        method: "POST",
        'credentials': 'include',
    })
        .then(res => res.json())
}

export function removeProductFromCart(productId, quantity = 1) {
    return fetch(`/api/cart/RemoveProduct?productId=${productId}&quantity=${quantity}`, {
        method: "DELETE",
        'credentials': 'include',
    })
        .then(res => res.json())
}