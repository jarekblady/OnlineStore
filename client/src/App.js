import { Container, createTheme, CssBaseline, ThemeProvider } from "@mui/material";
import { Route, Routes  } from "react-router";
import ProductDetails from "./features/products/ProductDetails";
import Products from "./features/products/Products";
import Home from "./features/home/Home";
import Navigation from "./Navigation";

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
            <Navigation/>
            <Container>
                <Routes>
                    <Route exact path='/' element={<Home />} />
                    <Route exact path='/product' element={<Products />} />
                    <Route path='/product/:id' element={<ProductDetails />} />
                </Routes>
            </Container>
        </ThemeProvider>
        
        
        );
        }

export default App;