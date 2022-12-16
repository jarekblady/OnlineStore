using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using OnlineStore.Repository.Entities;
using OnlineStore.Repository.Repositories.CartRepository;
using OnlineStore.Service.DTOs;

namespace OnlineStore.Service.Services.CartService
{
    public class CartService: ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        public CartService(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }


        public async Task<List<CartDto>> GetAllCarts()
        {
            var carts = await _cartRepository.GetAllCarts();
            return _mapper.Map<List<CartDto>>(carts);
        }

        public async Task<CartDto> GetByIdCart(int id)
        {
            var cart = await _cartRepository.GetByIdCart(id);
            return _mapper.Map<CartDto>(cart);
        }


        public async Task CreateCart(CartDto dto)
        {
            var cart = _mapper.Map<Cart>(dto);
            await _cartRepository.CreateCart(cart);
        }

        public async Task UpdateCart(CartDto dto)
        {
            var cart = _mapper.Map<Cart>(dto);
            await _cartRepository.UpdateCart(cart);
        }

        public async Task DeleteCart(int id)
        {
            var cart = await _cartRepository.GetByIdCart(id);
            _cartRepository.DeleteCart(cart);
        }
    }
}