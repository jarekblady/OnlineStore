import { Container, createTheme, CssBaseline, ThemeProvider } from "@mui/material";
import { Route, Routes } from "react-router";
import ProductDetails from "./components/products/ProductDetails";
import Products from "./components/products/Products";
import Home from "./components/home/Home";
import Cart from "./components/cart/Cart";
import Checkout from "./components/checkout/Checkout";
import Login from "./components/account/Login";
import Register from "./components/account/Register";
import Navigation from "./Navigation";
import { useEffect } from "react";
import { useStoreContext } from "./context/StoreContext";
import GetCart from "./fetch/getCart";

function App() {
    const { setCart } = useStoreContext();

    
    useEffect(() => {
        const customerId = getCookie('customerId');
        if (customerId) {
            GetCart()
                .then(cart => setCart(cart))
        }
    }, [setCart])
    
    function getCookie(key) {
        const b = document.cookie.match("(^|;)\\s*" + key + "\\s*=\\s*([^;]+)");
        return b ? b.pop() : "";
    }

    const theme = createTheme({
        palette: {
            background: {
                default: '#9adcfb'
            }
        }
    })
    return (
        <ThemeProvider theme={theme}>
            <CssBaseline />
            <Navigation />
            <Container>
                <Routes>
                    <Route exact path='/' element={<Home />} />
                    <Route exact path='/product' element={<Products />} />
                    <Route path='/product/:id' element={<ProductDetails />} />
                    <Route path='/cart' element={<Cart />} />
                    <Route path='/checkout' element={<Checkout />} />
                    <Route path='/login' element={<Login />} />
                    <Route path='/register' element={<Register />} />
                </Routes>
            </Container>
        </ThemeProvider>


    );
}

export default App;