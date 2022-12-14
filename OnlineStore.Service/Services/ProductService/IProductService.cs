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
        List<ProductDto> GetAllProducts();
        ProductDto GetByIdProduct(int id);
        void CreateProduct(ProductDto dto);
        void UpdateProduct(ProductDto dto);
        void DeleteProduct(int id);
    }
}
