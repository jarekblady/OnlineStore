import { useState, useEffect } from "react";
import ProductList from "./ProductList";
import agent from "../../api/agent";

function Products() {
    const [products, setProducts] = useState([]);


    useEffect(() => {
        agent.Products.getAllProducts()
            .then(products => setProducts(products));
    }, [])

    return (
        <>
            <ProductList products={products} />
        </>
    )
}

export default Products
