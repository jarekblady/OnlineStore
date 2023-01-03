import { createContext, useContext, useState } from "react";


export const StoreContext = createContext(undefined);

export function useStoreContext() {
    const context = useContext(StoreContext);

    if (context === undefined) {
        throw Error('Oops - we do not seem to be inside the provider');
    }

    return context;
}

export function StoreProvider({ children }) {
    const [cart, setCart] = useState(null);
    const [user, setUser] = useState(null);
    const [orderBy, setOrderBy] = useState("");
    const [searchTerm, setSearchTerm] = useState("");
    const [pageNumber, setPageNumber] = useState(1);
    const [pageSize, setPageSize] = useState(2);
    const [category, setCategory] = useState(0);
    const [brand, setBrand] = useState(0);
    const [products, setProducts] = useState([]);

    return (
        <StoreContext.Provider value={{
            cart, setCart,
            user, setUser,
            orderBy, setOrderBy,
            searchTerm, setSearchTerm,
            pageNumber, setPageNumber,
            pageSize, setPageSize,
            category, setCategory,
            brand, setBrand,
            products, setProducts
        }}>
            {children}
        </StoreContext.Provider>
    )
}