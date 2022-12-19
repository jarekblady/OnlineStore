using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Repository.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public ICollection<CartProduct> CartProducts { get; set; }
    }
}
