using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.Repository.Entities;

namespace OnlineStore.Repository.Repositories.OrderRepository
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllOrders();
        Task<List<Order>> GetAllOrdersForUser(int userId);
        Task<Order> GetByIdOrder(int id);
        Task CreateOrder(Order order);
        Task UpdateOrder(Order order);
    }
}
