using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Repository.Context;
using OnlineStore.Repository.Entities;

namespace OnlineStore.Repository.Repositories.OrderRepository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly StoreDbContext _context;

        public OrderRepository(StoreDbContext context)
        {
            _context = context;
        }
        public async Task<List<Order>> GetAllOrders()
        {

            return await _context.Orders.Include(u => u.User).Include(p => p.OrderProducts).ThenInclude(p => p.Product)
                .OrderByDescending(u => u.OrderDate.Date)
                .ToListAsync();
        }
        public async Task<List<Order>> GetAllOrdersForUser(int userId)
        {

            return await _context.Orders.Include(u => u.User).Include(p => p.OrderProducts).ThenInclude(p => p.Product).Where(u => u.UserId == userId)
                .OrderByDescending(u => u.OrderDate.Date)
                .ToListAsync();
        }

        public async Task<Order> GetByIdOrder(int id)
        {
            return await _context.Orders.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task CreateOrder(Order order)
        {

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

        }

        public async Task UpdateOrder(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();

        }

    }
}