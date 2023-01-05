using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Repository.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public double TotalCost { get; set; }
        public DateTime OrderDate { get; set; } 
        public string OrderStatus { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
