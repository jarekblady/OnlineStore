﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.Repository.Entities;
using OnlineStore.Service.DTOs;

namespace OnlineStore.Service.Services.CartService
{
    public interface ICartService
    {
        Task<CartDto> GetByIdCart(int id);
        Task<CartDto> GetCartForCookie(string cookie);
        Task<CartDto> CreateCart(CartDto dto);
        Task DeleteCart(int id);
        Task AddProduct(int cartId, int productId, int count);
        Task RemoveProduct(int cartId, int productId, int count);
    }
}
