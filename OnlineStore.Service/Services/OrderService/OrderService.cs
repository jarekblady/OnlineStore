using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using OnlineStore.Repository.Entities;
using OnlineStore.Repository.Repositories.CartRepository;
using OnlineStore.Repository.Repositories.OrderProductRepository;
using OnlineStore.Repository.Repositories.OrderRepository;
using OnlineStore.Repository.Repositories.ProductRepository;
using OnlineStore.Service.DTOs;

namespace OnlineStore.Service.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderProductRepository _orderProductRepository;
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IOrderProductRepository orderProductRepository, ICartRepository cartRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _orderProductRepository = orderProductRepository;
            _cartRepository = cartRepository;
            _mapper = mapper;
        }
        public async Task<List<OrderDto>> GetAllOrders()
        {
            var orders = await _orderRepository.GetAllOrders();
            return _mapper.Map < List<OrderDto>>(orders);
        }
        public async Task<List<OrderDto>> GetOrdersForUser(int userId)
        {
            var orders = await _orderRepository.GetAllOrdersForUser(userId);
            return _mapper.Map<List<OrderDto>>(orders);
        }
        public async Task<OrderDto> GetByIdOrder(int id)
        {
            var order = await _orderRepository.GetByIdOrder(id);
            return _mapper.Map<OrderDto>(order);
        }
        public async Task CreateOrder(int userId, string cookie)
        {
            var cart = await _cartRepository.GetCartForCookie(cookie);

            var order = new Order()
            {
                UserId = userId,
                OrderDate = DateTime.Now,
                TotalCost = cart.TotalCost,
                OrderStatus = "Pending",
            };

            await _orderRepository.CreateOrder(order);

            foreach (var product in cart.CartProducts)
            {
                var orderProduct = new OrderProduct()
                {
                    Order = order,
                    ProductId = product.ProductId,
                    Quantity = product.Quantity,
                };
                await _orderProductRepository.CreateOrderProduct(orderProduct);
            }

            _cartRepository.DeleteCart(cart);
        }
        public async Task UpdateOrder(int id, string orderStatus)
        {
            var order = await _orderRepository.GetByIdOrder(id);
            order.OrderStatus = orderStatus;
            await _orderRepository.UpdateOrder(order);
        }

    }
    
}