import { useState, useEffect} from "react";
import { Grid, Paper, TextField, FormControlLabel, Radio, RadioGroup, Pagination } from "@mui/material";
import ProductList from "./ProductList";
import GetProducts from "../../fetch/getProducts";


function Products() {
    const [products, setProducts] = useState([]);
    const [categories, setCategories] = useState([]);
    const [brands, setBrands] = useState([]);
    const [orderBy, setOrderBy] = useState("");
    const [searchPhrase, setSearchPhrase] = useState("");
    const [pageNumber, setPageNumber] = useState(1);
    const [pageSize] = useState(2);
    const [categoryId, setCategoryId] = useState(0);
    const [brandId, setBrandId] = useState(0);
    const [totalPages, setTotalPages] = useState(1);
    

    useEffect(() => {
        GetProducts(orderBy, categoryId, brandId, searchPhrase, pageNumber, pageSize)
            .then(result => {
                setProducts(result.items)
                setTotalPages(result.totalPages)
            });
            
    }, [orderBy, searchPhrase, pageNumber, pageSize, categoryId, brandId, totalPages])
    useEffect(() => {
        fetch('http://localhost:7204/api/product/categories', { method: 'GET' })
            .then(response => response.json())
            .then(categories => setCategories(categories));

    }, [])
    useEffect(() => {
        fetch('http://localhost:7204/api/product/brands', { method: 'GET' })
            .then(response => response.json())
            .then(brands => setBrands(brands));

    }, [])

    const handleBrand = (event) => {
        setBrandId(event.target.value);
        setPageNumber(1);
    };
    const handleCategory = (event) => {
        setCategoryId(event.target.value);
        setPageNumber(1);
    };
    const handleOrderBy = (event) => {
        setOrderBy(event.target.value);
        setPageNumber(1);
    };
    const handlePageNumber = (event, value) => {
        setPageNumber(value);
    };

    return (
        <Grid container columnSpacing={4}>
            <Grid item xs={3}>
                <Paper sx={{ mb: 2, p: 2  }}>
                    <TextField
                        label='Search products'
                        variant='outlined'
                        fullWidth
                        value={searchPhrase || ''}
                        onChange={(event) => {
                            setSearchPhrase(event.target.value);
                        }}
                    />
                </Paper>
                <Paper sx={{ mb: 2, p: 2 }}>
                    Categories:
                    <RadioGroup
                        aria-labelledby="demo-controlled-radio-buttons-group"
                        name="controlled-radio-buttons-group"
                        value={categoryId}
                        onChange={handleCategory}
                    >
                        <FormControlLabel value={0} control={<Radio />} label="All Categories" />
                        {categories.map(category => (
                            <FormControlLabel value={category.id} control={<Radio />} label={category.categoryName} />
                        ))}
                    </RadioGroup>
                </Paper>
                <Paper sx={{ mb: 2, p: 2 }}>
                    Brands:
                    <RadioGroup
                        aria-labelledby="demo-controlled-radio-buttons-group"
                        name="controlled-radio-buttons-group"
                        value={brandId}
                        onChange={handleBrand}
                    >
                        <FormControlLabel value={0} control={<Radio />} label="All Brands" />
                        {brands.map(brand => (
                            <FormControlLabel value={brand.id} control={<Radio />} label={brand.brandName} />
                            ))}
                    </RadioGroup>
                </Paper>
                <Paper sx={{ mb: 2, p: 2 }}>
                    Sorting: 
                    <RadioGroup
                        aria-labelledby="demo-controlled-radio-buttons-group"
                        name="controlled-radio-buttons-group"
                        value={orderBy}
                        onChange={handleOrderBy}
                    >
                        <FormControlLabel value={""} control={<Radio />} label="Alphabetically" />
                        <FormControlLabel value={"cost"} control={<Radio />} label="Cost: Low to High" />
                        <FormControlLabel value={"costDesc"} control={<Radio />} label="Cost: High to Low" />
                    </RadioGroup>
                </Paper>
            </Grid>
               
            <Grid item xs={9}>
                <ProductList products={products} />
            </Grid>
            <Grid item xs={3} />
            <Grid item xs={9} sx={{ mb: 2 }}>
                <Pagination
                    color='secondary'
                    size='large'
                    count={totalPages}
                    page={pageNumber}
                    onChange={handlePageNumber}
                   
                />
            </Grid>
        </Grid>
    )
}

export default Products
