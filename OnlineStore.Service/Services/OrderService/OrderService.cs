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
        private readonly IProductRepository _productRepository;
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IOrderProductRepository orderProductRepository, IProductRepository productRepository, ICartRepository cartRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _orderProductRepository = orderProductRepository;
            _productRepository = productRepository;
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

            var totalCost = 0.00;
            foreach (var product in cart.CartProducts)
            {
                totalCost += product.Count * product.Product.Cost;
            }
            var order = new Order()
            {
                UserId = userId,
                OrderDate = DateTime.Now,
                TotalCost = totalCost,
                OrderStatus = "Pending",
            };

            await _orderRepository.CreateOrder(order);

            foreach (var product in cart.CartProducts)
            {
                var orderProduct = new OrderProduct()
                {
                    Order = order,
                    ProductId = product.ProductId,
                    Quantity = product.Count,
                };
                await _orderProductRepository.CreateOrderProduct(orderProduct);
            }

            _cartRepository.DeleteCart(cart);
        }
        public async Task UpdateOrder(OrderDto dto)
        {
            var order = _mapper.Map<Order>(dto);
            await _orderRepository.UpdateOrder(order);
        }

    }
    
}