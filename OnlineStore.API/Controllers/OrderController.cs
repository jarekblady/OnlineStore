using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Service.DTOs;
using OnlineStore.Service.Services.OrderService;

namespace OnlineStore.API.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> GetOrders()
        {
            return Ok(await _orderService.GetAllOrders());
        }

        [HttpGet("ordersForUser")]
        [Authorize]
        public async Task<ActionResult> GetOrdersForUser()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            var userId = Convert.ToInt32(userIdClaim?.Value);
            return Ok(await _orderService.GetOrdersForUser(userId));
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> CreateOrder()
        {
            var cookie = Request.Cookies["customerId"];
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            var userId = Convert.ToInt32(userIdClaim?.Value);

            await _orderService.CreateOrder(userId, cookie);
            return Ok();
        }
        /*
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateOrder(OrderDto order)
        {
            await _orderService.UpdateOrder(order);
            return Ok();
        }*/

    }
}
