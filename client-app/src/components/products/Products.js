import { useState, useEffect} from "react";
import { Grid, Paper, TextField, FormControlLabel, Radio, RadioGroup, Pagination } from "@mui/material";
import { InputLabel, MenuItem, FormControl, Select } from "@mui/material";
import ProductList from "./ProductList";
import { getProducts } from "../../services/ProductService";
import { getCategories } from "../../services/CategoryService";
import { getBrands } from "../../services/BrandService";

function Products() {
    const [products, setProducts] = useState([]);
    const [categories, setCategories] = useState([]);
    const [brands, setBrands] = useState([]);
    const [orderBy, setOrderBy] = useState("");
    const [searchPhrase, setSearchPhrase] = useState("");
    const [pageNumber, setPageNumber] = useState(1);
    const [pageSize, setPageSize] = useState(3);
    const [categoryId, setCategoryId] = useState(0);
    const [brandId, setBrandId] = useState(0);
    const [totalPages, setTotalPages] = useState(1);
    
    useEffect(() => {
        getProducts(orderBy, categoryId, brandId, searchPhrase, pageNumber, pageSize)
            .then(result => {
                setProducts(result.items)
                setTotalPages(result.totalPages)
            });
            
    }, [orderBy, searchPhrase, pageNumber, pageSize, categoryId, brandId, totalPages])

    useEffect(() => {
        getCategories()
            .then(categories => setCategories(categories));

    }, [])

    useEffect(() => {
        getBrands()
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
    const handleChange = (event) => {
        setPageSize(event.target.value);
        setPageNumber(1);
    };

    return (
        <Grid container columnSpacing={4}>
            <Grid item xs={3}>
                <Paper sx={{ mb: 2, p: 2  }}>
                    <TextField sx={{ mb: 2}}
                        label='Search products'
                        variant='outlined'
                        fullWidth
                        value={searchPhrase || ''}
                        onChange={(event) => {
                            setSearchPhrase(event.target.value);
                        }}
                    />
                    Categories:
                    <RadioGroup sx={{ mb: 2 }}
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
                    Brands:
                    <RadioGroup sx={{ mb: 2 }}
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
                    Sorting: 
                    <RadioGroup sx={{ mb: 2 }}
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
               
            <Grid item xs={9} sx={{ mb: 2 }}>
                <ProductList products={products} />
            </Grid>
            <Grid item xs={3} />
            <Grid item xs={9} sx={{ mb: 2 }}>

                <FormControl sx={{ m: 1, minWidth: 80, mb: 2 }}>
                    <InputLabel id="demo-simple-select-label">PageSize</InputLabel>
                    <Select
                        labelId="demo-simple-select-label"
                        id="demo-simple-select"
                        value={pageSize}
                        label="pageSize"
                        onChange={handleChange}
                    >
                        <MenuItem value={3}>3</MenuItem>
                        <MenuItem value={6}>6</MenuItem>
                        <MenuItem value={9}>9</MenuItem>
                    </Select>
                </FormControl>
                <Pagination sx={{ mb: 2 }}
                    color='warning'
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
