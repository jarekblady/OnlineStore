export function getProductDetails(productId) {
    return fetch(`/api/product/${productId}`, {
        method: "GET"
    })
        .then(res => res.json())
}

export function getProducts(orderBy, categoryId, brandId, searchPhrase, pageNumber, pageSize) {
    return fetch(`/api/product?orderBy=${orderBy}&categoryId=${categoryId}&brandId=${brandId}&searchPhrase=${searchPhrase}&pageNumber=${pageNumber}&pageSize=${pageSize}`, {
        method: "GET"
    })
        .then(res => res.json())
}