export function  getCategories() {
        return fetch(`/api/category`, {
            method: "GET",
        })
            .then(res => res.json())
}
