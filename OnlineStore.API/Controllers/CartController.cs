using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Repository.Entities;
using OnlineStore.Service.DTOs;
using OnlineStore.Service.Services.CartService;

namespace OnlineStore.API.Controllers
{
    [Route("api/cart")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }
        [HttpGet]
        public async Task<ActionResult<CartDto>> GetCart()
        {
            var cart = await RetrieveCart();

            if (cart == null) return NotFound();

            return cart;
        }


        [HttpPost("AddProduct")]
        public async Task<ActionResult> AddProductToCart(int productId, int count)
        {
            var cart = await RetrieveCart();

            if (cart == null) cart = await CreateCart();

            await _cartService.AddProduct(cart.Id, productId, count);
            var dto = await _cartService.GetByIdCart(cart.Id);
            return Ok(dto);
        }

        [HttpDelete("RemoveProduct")]
        public async Task<ActionResult> RemoveProductFromCart(int productId, int count)
        {
            var cart = await RetrieveCart();

            await _cartService.RemoveProduct(cart.Id, productId, count);

            var dto = await _cartService.GetByIdCart(cart.Id);
            return Ok(dto);
        }
        
        
        private async Task<CartDto> RetrieveCart()
        {
            var carts = await _cartService.GetAllCarts();
            return carts.FirstOrDefault(x => x.CustomerId == Request.Cookies["customerId"]);

        }

        private async Task<CartDto> CreateCart()
        {
            var customerId = Guid.NewGuid().ToString();
            var cookieOptions = new CookieOptions { IsEssential = true, Expires = DateTime.Now.AddDays(30) };
            Response.Cookies.Append("customerId", customerId, cookieOptions);
            var cart = new CartDto { CustomerId = customerId };
            return await _cartService.CreateCart(cart);
        }
        


    }
}