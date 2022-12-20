import { useState, useEffect } from "react";
import ProductList from "./ProductList";
import agent from "../../app/api/agent";

function Products() {
    const [products, setProducts] = useState([]);
    const [loading, setLoading] = useState(true);


    useEffect(() => {
        agent.Products.list()
            .then(products => setProducts(products))
            .catch(error => console.log(error))
            .finally(() => setLoading(false));
    }, [])

    return (
        <>
            <ProductList products={products} />
        </>
    )
}

export default Products
