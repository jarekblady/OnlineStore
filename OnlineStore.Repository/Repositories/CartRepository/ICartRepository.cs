using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.Repository.Entities;

namespace OnlineStore.Repository.Repositories.CartRepository
{
    public interface ICartRepository
    {
        Task<List<Cart>> GetAllCarts();
        Task<Cart> GetByIdCart(int id);
        Task CreateCart(Cart cart);
        Task UpdateCart(Cart cart);
        void DeleteCart(Cart cart);
    }
}
