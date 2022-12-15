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
            new Product{Name="Samsung S21", Description="Smartphone", Cost=3000, Brand="Samsung",PictureUrl = "/images/products/Samsung.PNG"},
            new Product{Name="Samsung S22", Description="Smartphone", Cost=3000, Brand="Samsung",PictureUrl = "/images/products/Samsung.PNG"},
            new Product{Name="Samsung S23", Description="Smartphone", Cost=3000, Brand="Samsung",PictureUrl = "/images/products/Samsung.PNG"},
            new Product{Name="Samsung S24", Description="Smartphone", Cost=3000, Brand="Samsung",PictureUrl = "/images/products/Samsung.PNG"},
            new Product{Name="Samsung S25", Description="Smartphone", Cost=3000, Brand="Samsung",PictureUrl = "/images/products/Samsung.PNG"},
            new Product{Name="Samsung S26", Description="Smartphone", Cost=3000, Brand="Samsung",PictureUrl = "/images/products/Samsung.PNG"},

                };
            foreach (Product p in products)
            {
                context.Products.Add(p);
            }
            context.SaveChanges();
        }
    }
}
