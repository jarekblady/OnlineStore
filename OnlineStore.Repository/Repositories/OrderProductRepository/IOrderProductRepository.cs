using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.Repository.Entities;

namespace OnlineStore.Repository.Repositories.OrderProductRepository
{
    public interface IOrderProductRepository
    {
        Task CreateOrderProduct(OrderProduct orderProduct);
    }
}
