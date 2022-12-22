import { Button, Card, CardActions, CardContent, CardHeader, CardMedia, Typography } from "@mui/material";
import { Link } from "react-router-dom";
import agent from "../../api/agent";
import { useState } from "react";
import { useStoreContext } from "../../context/StoreContext";

function ProductCard(props) {
    const product = props.product;
    const [loading, setLoading] = useState(true);
    const { setCart } = useStoreContext();

    function handleAddItem(productId) {
        
        agent.Cart.addProduct(productId)
            .then(cart => setCart(cart))
            .catch (error => console.log(error))
            .finally(() => setLoading(false));              
    }

    return (
        <Card>
            <CardHeader
                title={product.name}
                titleTypographyProps={{
                    sx: { fontWeight: 'bold', color: 'warning.main' }
                }}
            />
            <CardMedia
                sx={{ height: 150, backgroundSize: 'contain' }}
                image={product.pictureUrl}
                title={product.name}
            />
            <CardContent>
                <Typography gutterBottom color='warning' variant="h5">
                    ${(product.cost).toFixed(2)}
                </Typography>
                <Typography variant="body2" color="info.main">
                    Brand: {product.brand} 
                </Typography>
            </CardContent>
            <CardActions>
                <Button color='success' onClick={() => handleAddItem(product.id)} size="small">Add to cart</Button>
                <Button color='secondary' component={Link} to={`/product/${product.id}`} size="small">Details</Button>
            </CardActions>
        </Card>
    )
}

export default ProductCard