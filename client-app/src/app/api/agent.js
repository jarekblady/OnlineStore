import axios from "axios";

axios.defaults.baseURL = 'http://localhost:7204/api/';
axios.defaults.withCredentials = true;

const responseBody = (response) => response.data;

const requests = {
    get: (url) => axios.get(url).then(responseBody),
    post: (url, body) => axios.post(url, body).then(responseBody),
    put: (url, body) => axios.put(url, body).then(responseBody),
    delete: (url) => axios.delete(url).then(responseBody),
}

const Products = {
    list: () => requests.get('product'),
    details: (id) => requests.get(`product/${id}`)
}


const Cart = {
    get: () => requests.get('cart'),
    addProduct: (productId, count = 1) => requests.post(`cart/AddProduct?productId=${productId}&count=${count}`, {}),
    removeProduct: (productId, count = 1) => requests.delete(`cart/RemoveProduct?productId=${productId}&count=${count}`)
}

const agent = {
    Products,
    Cart
}

export default agent;