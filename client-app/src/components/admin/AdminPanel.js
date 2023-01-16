import { Button, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Typography } from "@mui/material";
import { Box } from "@mui/system";
import { useState, useEffect } from "react";
import { useStoreContext } from "../../context/StoreContext";
import { getOrders, updateOrderStatus } from "../../services/OrderService";

function AdminPanel() {
    const { user } = useStoreContext();
    const [orders, setOrders] = useState([]);

    useEffect(() => {
        getOrders(user.token)
            .then(orders => setOrders(orders));
    }, [user.token])

    function handleOrderStatus(id, orderStatus) {
        updateOrderStatus(id, orderStatus, user.token)
            .then(orders => setOrders(orders));
    }

    return (
        <>
            {orders.length === 0 ?
                <Typography variant='h3'>Admin Panel is available only to users with the admin role.</Typography> :
                <>
                    {orders?.map(order => (
                        <Paper sx={{ mb: 2 }}>
                            <Button sx={{ mb: 2 }}
                                onClick={() => handleOrderStatus(order.id, "accepted")}
                                variant='contained'
                                color="success"
                                size='large'
                                
                            >
                                Set status to accepted
                            </Button>
                            <Button sx={{ mb: 2 }}
                                onClick={() => handleOrderStatus(order.id, "rejected")}
                                variant='contained'
                                color="error"
                                size='large'

                            >
                                Set status to rejected
                            </Button>
                        <TableContainer>
                            <Table sx={{ minWidth: 650 }}>
                                <TableHead>
                                    <TableRow>
                                        <TableCell colSpan={2}>OrderDate</TableCell>
                                        <TableCell align="right">{order.orderDate.split('T')[0]} {order.orderDate.split('T')[1].split('.')[0]}</TableCell>
                                    </TableRow>
                                    <TableRow>
                                        <TableCell colSpan={2}>OrderStatus</TableCell>
                                        <TableCell align="right">{order.orderStatus}</TableCell>
                                    </TableRow>
                                    <TableRow>
                                        <TableCell colSpan={2}>TotalCost</TableCell>
                                        <TableCell align="right">${(order.totalCost).toFixed(2)}</TableCell>
                                    </TableRow>
                                </TableHead>
                            </Table>
                            <Table sx={{ minWidth: 650 }}>
                                <TableHead>
                                    <TableRow>
                                        <TableCell>Product</TableCell>
                                        <TableCell align="right">Cost</TableCell>
                                        <TableCell align="right">Quantity</TableCell>
                                        <TableCell align="right">Total</TableCell>
                                        <TableCell align="right"></TableCell>
                                    </TableRow>
                                </TableHead>
                                <TableBody>
                                    {order?.orderProducts.map(item => (
                                        <TableRow
                                            key={item.productId}
                                            sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                                        >
                                            <TableCell component="th" scope="row">
                                                <Box display='flex' alignItems='center'>
                                                    <img src={item.pictureUrl} alt={item.productName} style={{ height: 50, marginRight: 20 }} />
                                                    <span>{item.productName}</span>
                                                </Box>
                                            </TableCell>
                                            <TableCell align="right">${(item.cost).toFixed(2)}</TableCell>
                                            <TableCell align="right">{item.quantity}</TableCell>
                                            <TableCell align="right">${((item.cost) * item.quantity).toFixed(2)}</TableCell>
                                        </TableRow>
                                    ))}
                                </TableBody>
                            </Table>
                        </TableContainer>
                    </Paper>
                    ))}
                </>
            }
        </>
    )
}
export default AdminPanel