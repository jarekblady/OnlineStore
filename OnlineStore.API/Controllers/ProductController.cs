using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Repository;
using OnlineStore.Service.DTOs;
using OnlineStore.Service.Services.BrandService;
using OnlineStore.Service.Services.CategoryService;
using OnlineStore.Service.Services.ProductService;

namespace OnlineStore.API.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IBrandService _brandService;
        public ProductController(IProductService productService, ICategoryService categoryService, IBrandService brandService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _brandService = brandService;
        }


        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> GetAllProducts([FromQuery] ProductQuery query)
        {
            var products = await _productService.GetAllProducts(query);

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            return Ok(await _productService.GetByIdProduct(id));
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct(ProductDto dto)
        {
            await _productService.CreateProduct(dto);
            return Ok("Success");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(ProductDto dto)
        {
            await _productService.UpdateProduct(dto);
            return Ok("Success");
        }


        [HttpDelete("{id}")]

        public async Task<ActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteProduct(id);
            return Ok("Success");
        }
        
        [HttpGet("categories")]
        public async Task<ActionResult> GetAllCategories()
        {
            return Ok(await _categoryService.GetAllCategories());
        }

        [HttpGet("brands")]
        public async Task<ActionResult> GetAllBrands()
        {
            return Ok(await _brandService.GetAllBrands());
        }
        
    }
}
