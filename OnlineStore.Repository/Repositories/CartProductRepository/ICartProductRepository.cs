using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.Repository.Entities;

namespace OnlineStore.Repository.Repositories.CartProductRepository
{
    public interface ICartProductRepository
    {
        Task<CartProduct> GetCartProduct(int cartId, int productId);      
        Task CreateCartProduct(CartProduct cartProduct);
        Task UpdateCartProduct(CartProduct cartProduct);
        void DeleteCartProduct(CartProduct cartProduct);
    }
}
