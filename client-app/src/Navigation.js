import { ShoppingCart } from "@mui/icons-material";
import { AppBar, Badge, Box, IconButton, List, ListItem, Toolbar, Typography } from "@mui/material";
import { NavLink } from "react-router-dom";

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
                    <IconButton size='large' sx={{ color: 'inherit' }}>
                        <Badge badgeContent={1} color='secondary'>
                            <ShoppingCart />
                        </Badge>
                    </IconButton>
                </Box>
            </Toolbar>
        </AppBar>
    )
}

export default Navigation