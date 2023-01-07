using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Service.DTOs
{
    public class CartDto
    {
        public int Id { get; set; }
        public string CookieHTTP { get; set; }
        public double TotalCost { get; set; }
        public ICollection<CartProductDto> CartProducts { get; set; }
    }
}
