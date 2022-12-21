import { ShoppingCart } from "@mui/icons-material";
import { AppBar, Badge, Box, IconButton, Toolbar, Typography } from "@mui/material";
import { Link, NavLink } from "react-router-dom";
import { useStoreContext } from "./context/StoreContext";

function Navigation() {

    const navStyles = {        
        color: '#4a148c',
        textDecoration: 'none',
        typography: 'h6',
        '&:hover': {
            color: '#f44336'
        },
        '&.active': {
            color: '#cddc39'
        }
    };

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
                <Box display='flex' alignItems='center'>
                    <Typography variant='h6' component={NavLink} exact to='/product'
                        sx={navStyles}>
                        Products
                    </Typography>
                </Box>
                <Box display='flex' alignItems='center'>
                    <Typography variant='h6' component={NavLink} exact to='/login'
                        sx={navStyles}>
                        Login
                    </Typography>
                </Box>
                <Box display='flex' alignItems='center'>
                    <Typography variant='h6' component={NavLink} exact to='/register'
                        sx={navStyles}>
                        Register
                    </Typography>
                </Box>
                <Box display='flex' alignItems='center'>
                    <IconButton component={Link} to='/cart' size='large' sx={{ color: '#ff3d00' }}>
                        <Badge badgeContent={productCount} color='success'>
                            <ShoppingCart />
                        </Badge>
                    </IconButton>
                </Box>
            </Toolbar>
        </AppBar>
    )
}

export default Navigation