using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Service.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }
        public double TotalCost { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public ICollection<OrderProductDto> OrderProducts { get; set; }
    }
}
