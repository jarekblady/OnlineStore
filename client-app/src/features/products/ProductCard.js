import { Avatar, Button, Card, CardActions, CardContent, CardHeader, CardMedia, Typography } from "@mui/material";
import { Link } from "react-router-dom";
import agent from "../../app/api/agent";
import { useState, useEffect } from "react";
import { useStoreContext } from "../../app/context/StoreContext";

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
                avatar={
                    <Avatar sx={{ bgcolor: 'secondary.main' }}>
                        {product.name.charAt(0).toUpperCase()}
                    </Avatar>
                }
                title={product.name}
                titleTypographyProps={{
                    sx: { fontWeight: 'bold', color: 'primary.main' }
                }}
            />
            <CardMedia
                sx={{ height: 140, backgroundSize: 'contain', bgcolor: 'primary.light' }}
                image={product.pictureUrl}
                title={product.name}
            />
            <CardContent>
                <Typography gutterBottom color='secondary' variant="h5">
                    ${(product.cost / 100).toFixed(2)}
                </Typography>
                <Typography variant="body2" color="text.secondary">
                    Brand: {product.brand} 
                </Typography>
            </CardContent>
            <CardActions>
                <Button onClick={() => handleAddItem(product.id)} size="small">Add to cart</Button>
                <Button component={Link} to={`/product/${product.id}`} size="small">Details</Button>
            </CardActions>
        </Card>
    )
}

export default ProductCard