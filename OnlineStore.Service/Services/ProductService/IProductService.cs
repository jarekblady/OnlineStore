using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.Repository;
using OnlineStore.Service.DTOs;

namespace OnlineStore.Service.Services.ProductService
{
    public interface IProductService
    {
        Task<PagedResult<ProductDto>> GetAllProducts(ProductQuery query);
        Task <ProductDto> GetByIdProduct(int id);
        Task CreateProduct(ProductDto dto);
        Task UpdateProduct(ProductDto dto);
        Task DeleteProduct(int id);
    }
}
