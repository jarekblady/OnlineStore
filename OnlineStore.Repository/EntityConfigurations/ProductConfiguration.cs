using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Repository.Entities;

namespace OnlineStore.Repository.EntityConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name)
                .IsRequired();
            builder.Property(p => p.Cost)
                .IsRequired();
            builder.HasOne(b => b.Brand)
                .WithMany(c => c.Products)
                .HasForeignKey(b => b.BrandId);
            builder.HasOne(b => b.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(b => b.CategoryId);
        }
    }
}
