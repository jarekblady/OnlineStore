using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.Service.DTOs;

namespace OnlineStore.Service.Services.OrderService
{
    public interface IOrderService
    {
        Task<List<OrderDto>> GetAllOrders();
        Task<List<OrderDto>> GetOrdersForUser(int userId);
        Task<OrderDto> GetByIdOrder(int id);
        Task CreateOrder(int userId, string cookie);
        Task UpdateOrder(OrderDto orderDto);
    }
}
