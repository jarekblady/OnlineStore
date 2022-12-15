export default class Product {
    id = "";
    name = "";
    description = "";
    cost = "";
    brand = "";

    constructor(id, fullName) {
        this.id = id;
        this.name = name;
        this.description = description;
        this.cost = cost;
        this.brand = brand;

    }

    static fromResponse(response) {
        return new Product(response.id, response.name, response.description, response.cost, response.brand);
    }
}