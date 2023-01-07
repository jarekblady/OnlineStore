import { ShoppingCart } from "@mui/icons-material";
import { AppBar, Badge, IconButton, Toolbar, Typography } from "@mui/material";
import Container from '@mui/material/Container';
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

    const { cart, user, setUser } = useStoreContext();
    const productQuantity = cart?.cartProducts.reduce((sum, item) => sum + item.quantity, 0)

    return (
        <AppBar position='static'>
            <Container maxWidth="xl">
                <Toolbar  sx={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center' }}>
                    <Typography variant='h6' component={NavLink} exact to='/'
                        sx={navStyles}>
                        ONLINE STORE
                    </Typography>

                    <Typography variant='h6' component={NavLink} exact to='/product'
                        sx={navStyles}>
                        PRODUCTS
                    </Typography>
                   
                    {!user &&
                        <>
                        <Typography variant='h6' component={NavLink} exact to='/login'
                            sx={navStyles}>
                            LOGIN
                        </Typography>
                        <Typography variant='h6' component={NavLink} exact to='/register'
                            sx={navStyles}>
                            REGISTER
                        </Typography>
                        </>
                    }
                    {user &&
                        <Typography variant='h6'
                            sx={navStyles}>
                            {user.email}
                        </Typography>
                    }
                    {user &&
                        <>
                        <Typography variant='h6' component={NavLink} exact to='/orders'
                            sx={navStyles}
                        >
                            ORDERS
                        </Typography>
                        <Typography variant='h6' component={NavLink} exact to='/admin'
                            sx={navStyles}
                        >
                            ADMIN PANEL
                        </Typography>
                        <Typography variant='h6' component={NavLink} exact to='/login'
                            sx={navStyles}
                            onClick={() => { setUser() }}
                        >
                            LOG OUT
                        </Typography>
                         </>

                    }
                    <IconButton component={Link} to='/cart' size='large' sx={{ color: '#ff3d00' }}>
                        <Badge badgeContent={productQuantity} color='success'>
                            <ShoppingCart />
                        </Badge>
                    </IconButton>
                
                </Toolbar>
            </Container>
        </AppBar>
    )
}

export default Navigation