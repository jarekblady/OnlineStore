using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using OnlineStore.Repository.Entities;
using OnlineStore.Repository.Repositories.CartRepository;
using OnlineStore.Service.DTOs;
using OnlineStore.Repository.Repositories.CartProductRepository;

namespace OnlineStore.Service.Services.CartService
{
    public class CartService: ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly ICartProductRepository _cartProductRepository;
        private readonly IMapper _mapper;

        public CartService(ICartRepository cartRepository, ICartProductRepository cartProductRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _cartProductRepository = cartProductRepository;
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


        public async Task<CartDto> CreateCart(CartDto dto)
        {
            var cart = _mapper.Map<Cart>(dto);
            await _cartRepository.CreateCart(cart);
            return _mapper.Map<CartDto>(cart); 
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
        
        public async Task AddProduct(int cartId, int productId, int count)
        {
            var product = await _cartProductRepository.GetCartProduct(cartId, productId);
            if(product == null) { 
                var cartProduct = new CartProduct { CartId = cartId, ProductId = productId, Count = count };
                await _cartProductRepository.CreateCartProduct(cartProduct);
            }
            else
            {
                product.Count += count;
                await _cartProductRepository.UpdateCartProduct(product);
            }

        }

        public async Task RemoveProduct(int cartId, int productId, int count)
        {
            var product = await _cartProductRepository.GetCartProduct(cartId, productId);
            product.Count -= count;
            if(product.Count == 0)
            {
                _cartProductRepository.DeleteCartProduct(product);
            }
            else
            {
                await _cartProductRepository.UpdateCartProduct(product);
            }
        }
        
    }
}