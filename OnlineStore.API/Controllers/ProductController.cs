using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Repository;
using OnlineStore.Service.DTOs;
using OnlineStore.Service.Services.ProductService;

namespace OnlineStore.API.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
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
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> CreateProduct(ProductDto dto)
        {
            await _productService.CreateProduct(dto);
            return Ok("Success");
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateProduct(ProductDto dto)
        {
            await _productService.UpdateProduct(dto);
            return Ok("Success");
        }


        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteProduct(id);
            return Ok("Success");
        }
                
    }
}
