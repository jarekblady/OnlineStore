using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Repository.Context;
using OnlineStore.Repository.Entities;

namespace OnlineStore.Repository.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreDbContext _context;

        public ProductRepository(StoreDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllProducts()
        {

            return await _context.Products.ToListAsync();
        }


        public async Task <Product> GetByIdProduct(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task CreateProduct(Product product)
        {

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

        }

        public async Task UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();

        }
        public void DeleteProduct(Product product)
        {
            _context.Products.Remove(product);

            _context.SaveChanges();

        }
    }
}