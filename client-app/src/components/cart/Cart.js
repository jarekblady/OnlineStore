import { AddCircle, RemoveCircle, Clear } from "@mui/icons-material";
import { Button, IconButton, Grid, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Typography } from "@mui/material";
import { Box } from "@mui/system";
import { Link } from "react-router-dom";
import { useStoreContext } from "../../context/StoreContext";
import AddProductToCart from "../../fetch/addProductToCart";
import RemoveProductFromCart from "../../fetch/removeProductFromCart";

function Cart() {
    const { cart, setCart, user } = useStoreContext();

    const productCount = cart?.cartProducts.reduce((sum, item) => sum + item.count, 0);
    if (!productCount) return <Typography variant='h3'>Your cart is empty</Typography>

    function handleAddItem(productId) {
        AddProductToCart(productId)
            .then(cart => setCart(cart));
    }

    function handleRemoveItem(productId, count) {
        RemoveProductFromCart(productId, count)
            .then(cart => setCart(cart));
    }

    function handleRemoveAllItems() {
        
            cart.cartProducts.map(item => (
                RemoveProductFromCart(item.productId, item.count)
                    .then(cart => setCart(cart))
            ))
        
        productCount = cart?.cartProducts.reduce((sum, item) => sum + item.count, 0);
    }


    const total = cart?.cartProducts.reduce((sum, item) => sum + (item.count * item.cost), 0) ?? 0;

    return (
        <>
            <TableContainer component={Paper}>
                <Table sx={{ minWidth: 650 }}>
                    <TableHead>
                        <TableRow>
                            <TableCell>Product</TableCell>
                            <TableCell align="right">Cost</TableCell>
                            <TableCell align="center">Count</TableCell>
                            <TableCell align="right">TotalCost</TableCell>
                            <TableCell align="right"></TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {cart.cartProducts.map(item => (
                            <TableRow
                                key={item.productId}
                                sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                            >
                                <TableCell component="th" scope="row">
                                    <Box display='flex' alignItems='center'>
                                        <img src={item.pictureUrl} alt={item.name} style={{ height: 50, marginRight: 20 }} />
                                        <span>{item.name}</span>
                                    </Box>
                                </TableCell>
                                <TableCell align="right">${(item.cost).toFixed(2)}</TableCell>
                                <TableCell align="center">
                                    <IconButton
                                        onClick={() => handleRemoveItem(item.productId, 1)}
                                        color='error'>
                                        <RemoveCircle />
                                    </IconButton>
                                    {item.count}
                                    <IconButton
                                        onClick={() => handleAddItem(item.productId)}
                                        color='success'>
                                        <AddCircle />
                                    </IconButton>
                                </TableCell>
                                <TableCell align="right">${((item.cost) * item.count).toFixed(2)}</TableCell>
                                <TableCell align="right">
                                    <IconButton onClick={() => handleRemoveItem(item.productId, item.count)}
                                        color='error'>
                                        <Clear />
                                    </IconButton>
                                </TableCell>
                            </TableRow>
                        ))}
                    </TableBody>
                </Table>
            </TableContainer>
            <Grid container>
                <Grid item xs={6} />
                <Grid item xs={6}>
                    <TableContainer component={Paper} variant={'outlined'}>
                        <Table>
                            <TableBody>
                                <TableRow>
                                    <TableCell colSpan={2}>Total</TableCell>
                                    <TableCell align="right">${(total).toFixed(2)}</TableCell>
                                </TableRow>
                            </TableBody>
                        </Table>
                    </TableContainer>
                    {user ? (
                        <Button
                        onClick={() => handleRemoveAllItems()}
                        component={Link}
                            to= '/checkout'
                        variant='contained'
                        size='large'
                        fullWidth                      
                    >
                        Checkout
                    </Button>
                    ) : (
                    <Button                     
                        component={Link}
                        to = '/login'                       
                        variant='contained'
                        size='large'
                        fullWidth                      
                    >
                        Checkout
                        </Button>
                    )}
                </Grid>
            </Grid>
        </>

    )
}
export default Cart