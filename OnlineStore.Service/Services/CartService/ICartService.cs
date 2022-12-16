using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.Service.DTOs;

namespace OnlineStore.Service.Services.CartService
{
    public interface ICartService
    {
        Task<List<CartDto>> GetAllCarts();
        Task<CartDto> GetByIdCart(int id);
        Task CreateCart(CartDto dto);
        Task UpdateCart(CartDto dto);
        Task DeleteCart(int id);
    }
}
