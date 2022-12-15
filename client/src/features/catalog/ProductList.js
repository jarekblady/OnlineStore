import React from "react";
import { Grid } from "@mui/material";
import ProductCard from "./ProductCard";

function ProductList(props) {
    const products = props.products
    return (
        <Grid container spacing={4}>
            {products.map(product => (
                <Grid item xs={4} key={product.id}>
                    <ProductCard product={product} />
                </Grid>
            ))}
        </Grid>
    )
}

export default ProductList