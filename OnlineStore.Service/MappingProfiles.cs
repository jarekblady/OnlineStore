using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using OnlineStore.Repository.Entities;
using OnlineStore.Service.DTOs;

namespace OnlineStore.Service
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(d => d.Brand, o => o.MapFrom(s => s.Brand.BrandName))
                .ForMember(d => d.Category, o => o.MapFrom(s => s.Category.CategoryName)); ;
            CreateMap<ProductDto, Product>();

            CreateMap<Cart, CartDto>();
            CreateMap<CartDto, Cart>();

            CreateMap<CartProduct, CartProductDto>()
                .ForMember(d => d.Name, c => c.MapFrom(s => s.Product.Name))
                .ForMember(d => d.Description, c => c.MapFrom(s => s.Product.Description))
                .ForMember(d => d.Cost, c => c.MapFrom(s => s.Product.Cost))
                .ForMember(d => d.Brand, c => c.MapFrom(s => s.Product.Brand))
                .ForMember(d => d.PictureUrl, c => c.MapFrom(s => s.Product.PictureUrl));
            CreateMap<CartProductDto, CartProduct>();
        }
    }
}
