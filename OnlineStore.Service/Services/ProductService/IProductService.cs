using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.Service.DTOs;

namespace OnlineStore.Service.Services.ProductService
{
    public interface IProductService
    {
        Task <List<ProductDto>> GetAllProducts();
        Task <ProductDto> GetByIdProduct(int id);
        Task CreateProduct(ProductDto dto);
        Task UpdateProduct(ProductDto dto);
        Task DeleteProduct(int id);
    }
}
