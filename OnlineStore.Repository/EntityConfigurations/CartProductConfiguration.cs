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
    internal class CartProductConfiguration : IEntityTypeConfiguration<CartProduct>
    {
        public void Configure(EntityTypeBuilder<CartProduct> builder)
        {
            builder.HasOne(b => b.Product)
                .WithMany(c => c.CartProducts)
                .HasForeignKey(b => b.ProductId);
            builder.HasOne(b => b.Cart)
                .WithMany(c => c.CartProducts)
                .HasForeignKey(b => b.CartId);

        }
    }
}
