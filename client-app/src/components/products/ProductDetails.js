import { Button, Divider, Grid, Table, TableBody, TableCell, TableContainer, TableRow, Typography } from "@mui/material";
import { useEffect, useState } from "react";
import { useParams } from "react-router";
import { useStoreContext } from "../../context/StoreContext";
import { getProductDetails } from "../../services/ProductService";
import { addProductToCart } from "../../services/CartService";

function ProductDetails() {
    const { id } = useParams();
    const [product, setProduct] = useState(null);
    const { setCart } = useStoreContext();
    
    useEffect(() => {
        getProductDetails(id)
            .then(result => {
                setProduct(result)
            });
    }, [id]);
    
    if (!product) return <h3>Product not found</h3>

    function handleAddItem(productId) {

        addProductToCart(productId)
            .then(cart => setCart(cart));
    }

    return (
        <Grid container spacing={6}>
            <Grid item xs={6}>
                <img src={product.pictureUrl} alt={product.name} style={{ height: 300}} />
            </Grid>
            <Grid item xs={6}>
                <Typography variant='h3'>{product.name}</Typography>
                <Divider sx={{ mb: 2 }} />
                <Typography variant='h4' color='secondary'>${(product.cost).toFixed(2)}</Typography>
                <TableContainer>
                    <Table>
                        <TableBody>
                            <TableRow>
                                <TableCell>Name</TableCell>
                                <TableCell>{product.name}</TableCell>
                            </TableRow>
                            <TableRow>
                                <TableCell>Description</TableCell>
                                <TableCell>{product.description}</TableCell>
                            </TableRow>
                            <TableRow>
                                <TableCell>Brand</TableCell>
                                <TableCell>{product.brand}</TableCell>
                            </TableRow>
                        </TableBody>
                    </Table>
                </TableContainer>
                <Grid container spacing={2}>
                    <Grid item xs={6}>
                        <Button
                            onClick={() =>handleAddItem(product.id)}
                            sx={{ height: '50px' }}
                            color='success'
                            size='large'
                            variant='contained'
                            fullWidth
                        >
                            Add to cart
                        </Button>
                    </Grid>
                </Grid>
            </Grid>
        </Grid>
    )
}

export default ProductDetails