import { ShoppingCart } from "@mui/icons-material";
import { AppBar, Badge, Box, IconButton, List, ListItem, Toolbar, Typography } from "@mui/material";
import { Link, NavLink } from "react-router-dom";
import { useState, useEffect } from "react";
import agent from "./app/api/agent";
import { useStoreContext } from "./app/context/StoreContext";

function Navigation() {
    const midLinks = [
        { title: 'products', path: '/product' }
    ];

    const rightLinks = [
        { title: 'login', path: '/login' },
        { title: 'register', path: '/register' }
    ];

    const navStyles = {
        color: 'inherit',
        textDecoration: 'none',
        typography: 'h6',
        '&:hover': {
            color: 'grey.500'
        },
        '&.active': {
            color: 'text.secondary'
        }
    };

    //const [cart, setCart] = useState(null);
    //const [loading, setLoading] = useState(true);
    /*
    useEffect(() => {
        agent.Cart.get()
            .then(cart => setCart(cart))
            .catch(error => console.log(error))
            .finally(() => setLoading(false));
    }, [])
    */
    const { cart } = useStoreContext();
    const productCount = cart?.cartProducts.reduce((sum, item) => sum + item.count, 0)

    return (
        <AppBar position='static' sx={{ mb: 4 }}>
            <Toolbar sx={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center' }}>
                <Box display='flex' alignItems='center'>
                    <Typography variant='h6' component={NavLink} exact to='/'
                        sx={navStyles}>
                        ONLINE STORE
                    </Typography>
                </Box>
                <List sx={{ display: 'flex' }}>
                    {midLinks.map(({ title, path }) => (
                        <ListItem
                            component={NavLink}
                            to={path}
                            key={path}
                            sx={navStyles}
                        >
                            {title.toUpperCase()}
                        </ListItem>
                    ))}
                </List>
                <Box display='flex' alignItems='center'>
                    <List sx={{ display: 'flex' }}>
                        {rightLinks.map(({ title, path }) => (
                            <ListItem
                                component={NavLink}
                                to={path}
                                key={path}
                                sx={navStyles}
                            >
                                {title.toUpperCase()}
                            </ListItem>
                        ))}
                    </List>
                    <IconButton component={Link} to='/cart' size='large' sx={{ color: 'inherit' }}>
                        <Badge badgeContent={productCount} color='secondary'>
                            <ShoppingCart />
                        </Badge>
                    </IconButton>
                </Box>
            </Toolbar>
        </AppBar>
    )
}

export default Navigation