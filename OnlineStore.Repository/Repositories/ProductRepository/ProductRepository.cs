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

        public async Task<PagedResult<Product>> GetAllProducts(ProductQuery query)
        {

            var baseQuery = _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .Sort(query.OrderBy)
                .Search(query.SearchPhrase)
                .Filter(query.BrandId, query.CategoryId);


            
            var products = await baseQuery
                .Skip(query.PageSize * (query.PageNumber - 1))
                .Take(query.PageSize)
                .ToListAsync();

            var totalItemsCount = baseQuery.Count();

            var result = new PagedResult<Product>(products, totalItemsCount, query.PageSize, query.PageNumber);

            return result;
        }

        public async Task <Product> GetByIdProduct(int id)
        {
            return await _context.Products.Include(x => x.Brand).Include(x => x.Category).FirstOrDefaultAsync(p => p.Id == id);
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