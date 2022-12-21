import { Container, createTheme, CssBaseline, ThemeProvider } from "@mui/material";
import { Route, Routes } from "react-router";
import ProductDetails from "./features/products/ProductDetails";
import Products from "./features/products/Products";
import Home from "./features/home/Home";
import Cart from "./features/cart/Cart";
import Checkout from "./features/checkout/Checkout";
import Login from "./features/account/Login";
import Register from "./features/account/Register";
import Navigation from "./Navigation";
import { useEffect, useState } from "react";
import { useStoreContext } from "./context/StoreContext";
import agent from "./app/api/agent";

function App() {
    const { setCart } = useStoreContext();
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        const customerId = getCookie('customerId');
        if (customerId) {
            agent.Cart.get()
                .then(cart => setCart(cart))
                .catch(error => console.log(error))
                .finally(() => setLoading(false))
        } else {
            setLoading(false);
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