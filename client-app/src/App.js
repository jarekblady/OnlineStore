import { Container, createTheme, CssBaseline, ThemeProvider } from "@mui/material";
import { Route, Routes } from "react-router";
import ProductDetails from "./features/products/ProductDetails";
import Products from "./features/products/Products";
import Home from "./features/home/Home";
import Cart from "./features/cart/Cart";
import Navigation from "./Navigation";
import { useEffect, useState } from "react";
import { useStoreContext } from "./app/context/StoreContext";
import { getCookie } from "./app/util/util";
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
            <Navigation />
            <Container>
                <Routes>
                    <Route exact path='/' element={<Home />} />
                    <Route exact path='/product' element={<Products />} />
                    <Route path='/product/:id' element={<ProductDetails />} />
                    <Route path='/cart' element={<Cart />} />
                </Routes>
            </Container>
        </ThemeProvider>


    );
}

export default App;