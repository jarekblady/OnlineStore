import { Add, Delete, Remove } from "@mui/icons-material";
//import { LoadingButton } from "@mui/lab";
import { Button, IconButton, Grid, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Typography } from "@mui/material";
import { Box } from "@mui/system";
import { useState, useEffect } from "react";
import { Link } from "react-router-dom";
import agent from "../../app/api/agent";
//import { useStoreContext } from "../../app/context/StoreContext";
//import BasketSummary from "./BasketSummary";

function Cart() {
    const [cart, setCart] = useState(null);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        agent.Cart.get()
            .then(cart => setCart(cart))
            .catch(error => console.log(error))
            .finally(() => setLoading(false));
    }, [])


    /*
    function handleAddItem(productId, name) {
        setStatus({ loading: true, name });
        agent.Cart.addProduct(productId)
            .catch(error => console.log(error))
            .finally(() => setStatus({ loading: false, name: '' }))
    }

    function handleRemoveItem(productId, count = 1, name) {
        setStatus({ loading: true, name });
        agent.Cart.removeProduct(productId, count)
            .catch(error => console.log(error))
            .finally(() => setStatus({ loading: false, name: '' }));
    }*/

    if (!cart) return <Typography variant='h3'>Your cart is empty</Typography>

    return (
        <>
            <TableContainer component={Paper}>
                <Table sx={{ minWidth: 650 }}>
                    <TableHead>
                        <TableRow>
                            <TableCell>Product</TableCell>
                            <TableCell align="right">Cost</TableCell>
                            <TableCell align="right">Count</TableCell>
                            <TableCell align="right">Subtotal</TableCell>
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
                                <TableCell align="right">${(item.cost / 100).toFixed(2)}</TableCell>
                                <TableCell align="right">{item.count}</TableCell>

                                <TableCell align="right">${((item.cost / 100) * item.count).toFixed(2)}</TableCell>
                                <TableCell align="right">
                                    <IconButton color='error'>
                                        <Delete />
                                    </IconButton>
                                </TableCell>
                            </TableRow>
                        ))}
                    </TableBody>
                </Table>
            </TableContainer>
            
        </>

    )
}
export default Cart