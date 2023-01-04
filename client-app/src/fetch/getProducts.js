import { baseURL } from "./baseURL";

export default function GetProducts(orderBy, categoryId, brandId, searchPhrase, pageNumber, pageSize) {
    return fetch(baseURL +`product?orderBy=${orderBy}&categoryId=${categoryId}&brandId=${brandId}&searchPhrase=${searchPhrase}&pageNumber=${pageNumber}&pageSize=${pageSize}`, {
        method: "GET"
    })
        .then(res => res.json())
}