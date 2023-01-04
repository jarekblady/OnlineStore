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
            var roles = new Role[]
{
                new Role() { RoleName = "Admin"},
                new Role() { RoleName = "User"}
};

            if (!context.Roles.Any())
            {
                foreach (Role r in roles)
                {
                    context.Roles.Add(r);
                }
                context.SaveChanges();
            }

            var categories = new Category[]
            {
                new Category() { CategoryName = "Smartphones"},
                new Category() { CategoryName = "Computers"}
            };

            if (!context.Categories.Any())
            {
                foreach (Category c in categories)
                {
                    context.Categories.Add(c);
                }
                context.SaveChanges();
            }
            var brands = new Brand[]
            {
                new Brand() { BrandName = "Samsung"},
                new Brand() { BrandName = "OnePlus"},
                new Brand() { BrandName = "Motorola"}
            };
            if (!context.Brands.Any())
            {
                context.Brands.AddRange(brands);
                context.SaveChanges();
            }

            var products = new Product[]
            {
            new Product
            {
                Name="SAMSUNG Galaxy Z Fold",
                Description="Factory Unlocked Android Smartphone, 512GB, Flex Mode, Hands Free Video, Multi Window View, Foldable Display, S Pen Compatible, US Version, Beige",
                Cost=1540,
                PictureUrl = "/images/products/SamsungZFold4.PNG",
                BrandId=1,
                CategoryId=1
            },
            new Product
            {
                Name="SAMSUNG Galaxy S22",
                Description="Factory Unlocked Android Smartphone, 512GB, 8K Camera & Video, Brightest Display Screen, S Pen, Long Battery Life, Fast 4nm Processor, US Version, Phantom Black",
                Cost=1200,
                PictureUrl = "/images/products/SamsungS22Ultra.PNG",
                BrandId=1,
                CategoryId=1
            },
            new Product
            {
                Name="OnePlus 10 Pro",
                Description="5G Android Smartphone | 8GB+128GB | U.S. Unlocked | Triple Camera co-Developed with Hasselblad | Volcanic Black",
                Cost=600,
                PictureUrl = "/images/products/OnePlus10Pro.PNG",
                BrandId=2,
                CategoryId=1
            },
            new Product
            {
                Name="Moto G Stylus 5G",
                Description="2-Day battery | Unlocked | Made for US by Motorola | 6/256GB | 48MP Camera | Cosmic Emerald",
                Cost=200,
                PictureUrl = "/images/products/MotoG.PNG",
                BrandId=3,
                CategoryId=1
            }
            };


            if (!context.Products.Any())
            {
                context.Products.AddRange(products);
                context.SaveChanges();
            }

        }
        private IEnumerable<Category> GetCategories()
        {
            return new List<Category>()
            {
                new Category() { CategoryName = "Smartphones"},
                new Category() { CategoryName = "Computers"}
            };
        }
        private IEnumerable<Brand> GetBrands()
        {
            return new List<Brand>()
            {
                new Brand() { BrandName = "Samsung"},
                new Brand() { BrandName = "OnePlus"},
                new Brand() { BrandName = "Motorola"}
            };
        }
        private IEnumerable<Product> GetProducts()
        {
            return new List<Product>()
            {
            new Product
            {
                Name="SAMSUNG Galaxy Z Fold",
                Description="Factory Unlocked Android Smartphone, 512GB, Flex Mode, Hands Free Video, Multi Window View, Foldable Display, S Pen Compatible, US Version, Beige",
                Cost=1540,
                PictureUrl = "/images/products/SamsungZFold4.PNG",
                BrandId=1,
                CategoryId=1
            },
            new Product
            {
                Name="SAMSUNG Galaxy S22",
                Description="Factory Unlocked Android Smartphone, 512GB, 8K Camera & Video, Brightest Display Screen, S Pen, Long Battery Life, Fast 4nm Processor, US Version, Phantom Black",
                Cost=1200,
                PictureUrl = "/images/products/SamsungS22Ultra.PNG",
                BrandId=1,
                CategoryId=1
            },
            new Product
            {
                Name="OnePlus 10 Pro",
                Description="5G Android Smartphone | 8GB+128GB | U.S. Unlocked | Triple Camera co-Developed with Hasselblad | Volcanic Black",
                Cost=600,
                PictureUrl = "/images/products/OnePlus10Pro.PNG",
                BrandId=2,
                CategoryId=1
            },
            new Product
            {
                Name="Moto G Stylus 5G",
                Description="2-Day battery | Unlocked | Made for US by Motorola | 6/256GB | 48MP Camera | Cosmic Emerald",
                Cost=200,
                PictureUrl = "/images/products/MotoG.PNG",
                BrandId=3,
                CategoryId=1
            }
            };
        }
    }
}
