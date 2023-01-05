using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.Repository.Context;
using OnlineStore.Repository.Entities;

namespace OnlineStore.Repository.Repositories.OrderProductRepository
{
    public class OrderProductRepository : IOrderProductRepository
    {
        private readonly StoreDbContext _context;

        public OrderProductRepository(StoreDbContext context)
        {
            _context = context;
        }

        public async Task CreateOrderProduct(OrderProduct orderProduct)
        {
            await _context.OrderProducts.AddAsync(orderProduct);
            await _context.SaveChangesAsync();
        }
    }
}