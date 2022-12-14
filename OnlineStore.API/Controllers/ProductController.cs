using Microsoft.AspNetCore.Mvc;
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
        public ActionResult<IEnumerable<ProductDto>> GetAllProducts()
        {

            return Ok(_productService.GetAllProducts());
        }

        [HttpGet("{id}")]
        public ActionResult<ProductDto> GetProduct(int id)
        {

            return Ok(_productService.GetByIdProduct(id));

        }

        [HttpPost]
        public ActionResult CreateProduct(ProductDto dto)
        {
            _productService.CreateProduct(dto);

            return Ok("Success");
        }

        [HttpPut("{id}")]
        public ActionResult UpdateProduct(ProductDto dto)
        {

            _productService.UpdateProduct(dto);

            return Ok("Success");
        }


        [HttpDelete("{id}")]

        public ActionResult DeleteProduct(int id)
        {
            _productService.DeleteProduct(id);


            return NoContent();

        }

    }
}
