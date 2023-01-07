using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Service.DTOs
{
    public class CartProductDto
    {
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }       
        public string PictureUrl { get; set; }
    }
}
