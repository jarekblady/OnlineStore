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

    return (
        <StoreContext.Provider value={{
            cart, setCart,
            user, setUser
        }}>
            {children}
        </StoreContext.Provider>
    )
}