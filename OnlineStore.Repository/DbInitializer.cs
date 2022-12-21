using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.Repository.Context;
using OnlineStore.Repository.Entities;

namespace OnlineStore.Repository
{
    public class DbInitializer
    {
        public static void Initialize(StoreDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Products.Any())
            {
                return;
            }

            var products = new Product[]
            {
            new Product
            {
                Name="SAMSUNG Galaxy Z Fold", 
                Description="Factory Unlocked Android Smartphone, 512GB, Flex Mode, Hands Free Video, Multi Window View, Foldable Display, S Pen Compatible, US Version, Beige", 
                Cost=1540, 
                Brand="Samsung",
                PictureUrl = "/images/products/SamsungZFold4.PNG"
            },
            new Product
            {
                Name="SAMSUNG Galaxy S22",
                Description="Factory Unlocked Android Smartphone, 512GB, 8K Camera & Video, Brightest Display Screen, S Pen, Long Battery Life, Fast 4nm Processor, US Version, Phantom Black",
                Cost=1200,
                Brand="Samsung",
                PictureUrl = "/images/products/SamsungS22Ultra.PNG"
            },
            new Product
            {
                Name="OnePlus 10 Pro",
                Description="5G Android Smartphone | 8GB+128GB | U.S. Unlocked | Triple Camera co-Developed with Hasselblad | Volcanic Black",
                Cost=600,
                Brand="OnePlus",
                PictureUrl = "/images/products/OnePlus10Pro.PNG"
            },
            new Product
            {
                Name="Moto G Stylus 5G",
                Description="2-Day battery | Unlocked | Made for US by Motorola | 6/256GB | 48MP Camera | Cosmic Emerald",
                Cost=200,
                Brand="Motorola",
                PictureUrl = "/images/products/MotoG.PNG"
            },

                };
            foreach (Product p in products)
            {
                context.Products.Add(p);
            }
            context.SaveChanges();
        }
    }
}
