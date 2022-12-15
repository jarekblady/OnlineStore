import React from 'react';
import './App.css';
import { Container, createTheme, CssBaseline, ThemeProvider, AppBar, Toolbar, Typography } from "@mui/material";
import Catalog from "./features/catalog/Catalog";

function App() {
    const theme = createTheme({
        palette: {           
            background: {
                default: '#eaeaea' 
            }
        }
    })
    return (
        <ThemeProvider theme={theme}>
            <CssBaseline />
            <AppBar position='static' sx={{ mb: 4 }}>
                <Toolbar>
                    <Typography variant='h6'>
                        ONLINE STORE
                    </Typography>
                </Toolbar>
            </AppBar>
            <Container>
                <Catalog />
            </Container>
        </ThemeProvider>
        
        
        );
        }

export default App;