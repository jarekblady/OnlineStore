using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using OnlineStore.Repository;
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


        public async Task<PagedResult<ProductDto>> GetAllProducts(ProductQuery query)
        {
            var p = await _productRepository.GetAllProducts(query);
            var productsDtos = _mapper.Map<List<ProductDto>>(p.Items);


            var result = new PagedResult<ProductDto>(productsDtos, p.TotalItemsCount, p.ItemsFrom, p.ItemsTo, p.TotalPages);

            return result;
        }

        public async Task<ProductDto> GetByIdProduct(int id)
        {
            var product = await _productRepository.GetByIdProduct(id);
            return _mapper.Map<ProductDto>(product);
        }


        public async Task CreateProduct(ProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            await _productRepository.CreateProduct(product);
        }

        public async Task UpdateProduct(ProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            await _productRepository.UpdateProduct(product);
        }

        public async Task DeleteProduct(int id)
        {
            var product = await _productRepository.GetByIdProduct(id);
            _productRepository.DeleteProduct(product);
        }
    }
}
