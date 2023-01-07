import { AddCircle, RemoveCircle, Clear } from "@mui/icons-material";
import { Button, IconButton, Grid, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Typography } from "@mui/material";
import { Box } from "@mui/system";
import { Link } from "react-router-dom";
import { useStoreContext } from "../../context/StoreContext";
import AddProductToCart from "../../fetch/addProductToCart";
import RemoveProductFromCart from "../../fetch/removeProductFromCart";
import AddOrder from "../../fetch/addOrder";


function Cart() {
    const { cart, setCart, user } = useStoreContext();

    const productQuantity = cart?.cartProducts.reduce((sum, item) => sum + item.quantity, 0);
    if (!productQuantity) return <Typography variant='h3'>Your cart is empty</Typography>

    function handleAddItem(productId) {
        AddProductToCart(productId)
            .then(cart => setCart(cart));
    }

    function handleRemoveItem(productId, quantity) {
        RemoveProductFromCart(productId, quantity)
            .then(cart => setCart(cart));
    }

    function handleAddOrder() {
        AddOrder(user.token);
        setCart();
    }

    return (
        <>
            <TableContainer component={Paper}>
                <Table sx={{ minWidth: 650 }}>
                    <TableHead>
                        <TableRow>
                            <TableCell>Product</TableCell>
                            <TableCell align="right">Cost</TableCell>
                            <TableCell align="center">Quantity</TableCell>
                            <TableCell align="right">Total</TableCell>
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
                                    {item.quantity}
                                    <IconButton
                                        onClick={() => handleAddItem(item.productId)}
                                        color='success'>
                                        <AddCircle />
                                    </IconButton>
                                </TableCell>
                                <TableCell align="right">${((item.cost) * item.quantity).toFixed(2)}</TableCell>
                                <TableCell align="right">
                                    <IconButton onClick={() => handleRemoveItem(item.productId, item.quantity)}
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
                                    <TableCell colSpan={2}>TotalCost</TableCell>
                                    <TableCell align="right">${cart.totalCost}</TableCell>
                                </TableRow>
                            </TableBody>
                        </Table>
                    </TableContainer>
                    {user ? (
                        <Button
                            onClick={() => handleAddOrder()}
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