using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public List<Product> GetAllProducts()
        {

            return _context.Products.ToList();
        }


        public Product GetByIdProduct(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        public void CreateProduct(Product product)
        {

            _context.Products.Add(product);
            _context.SaveChanges();

        }

        public void UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();

        }
        public void DeleteProduct(Product product)
        {
            _context.Products.Remove(product);

            _context.SaveChanges();

        }
    }
}