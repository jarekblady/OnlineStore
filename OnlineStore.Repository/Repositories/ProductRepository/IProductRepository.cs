using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.Repository.Entities;

namespace OnlineStore.Repository.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task <List<Product>> GetAllProducts();
        Task <Product> GetByIdProduct(int id);
        Task CreateProduct(Product product);
        Task UpdateProduct(Product product);
        void DeleteProduct(Product product);
    }
}
