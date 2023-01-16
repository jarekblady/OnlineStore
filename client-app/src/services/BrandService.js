export function getBrands() {
    return fetch(`/api/brand`, {
        method: "GET",
    })
        .then(res => res.json())
}