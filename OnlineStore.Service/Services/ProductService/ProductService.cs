using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using OnlineStore.Repository.Entities;
using OnlineStore.Repository.Repositories.ProductRepository;
using OnlineStore.Service.DTOs;

namespace OnlineStore.Service.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }


        public List<ProductDto> GetAllProducts()
        {
            var products = _productRepository.GetAllProducts();
            var result = _mapper.Map<List<ProductDto>>(products);
            return result;
        }

        public ProductDto GetByIdProduct(int id)
        {
            var product = _productRepository.GetByIdProduct(id);
            var result = _mapper.Map<ProductDto>(product);
            return result;
        }


        public void CreateProduct(ProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            _productRepository.CreateProduct(product);
        }

        public void UpdateProduct(ProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            _productRepository.UpdateProduct(product);
        }

        public void DeleteProduct(int id)
        {
            var product = _productRepository.GetByIdProduct(id);
            _productRepository.DeleteProduct(product);
        }
    }
}
