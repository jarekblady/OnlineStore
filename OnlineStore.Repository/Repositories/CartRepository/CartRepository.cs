using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Repository.Context;
using OnlineStore.Repository.Entities;

namespace OnlineStore.Repository.Repositories.CartRepository
{
    public class CartRepository : ICartRepository
    {
        private readonly StoreDbContext _context;

        public CartRepository(StoreDbContext context)
        {
            _context = context;
        }

        public async Task<List<Cart>> GetAllCarts()
        {

            return await _context.Carts.Include(p => p.CartProducts).ThenInclude(p => p.Product).ToListAsync();
        }


        public async Task<Cart> GetByIdCart(int id)
        {
            return await _context.Carts.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task CreateCart(Cart cart)
        {

            await _context.Carts.AddAsync(cart);
            await _context.SaveChangesAsync();

        }

        public async Task UpdateCart(Cart cart)
        {
            _context.Carts.Update(cart);
            await _context.SaveChangesAsync();

        }
        public void DeleteCart(Cart cart)
        {
            _context.Carts.Remove(cart);

            _context.SaveChanges();

        }
    }
}
