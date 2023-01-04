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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(p => p.Email)
                .IsRequired();
            builder.Property(p => p.FirstName)
                .IsRequired();
            builder.Property(p => p.LastName)
                .IsRequired();
            builder.Property(p => p.PasswordHash)
                .IsRequired();
            builder.HasOne(b => b.Role)
                .WithMany(c => c.Users)
                .HasForeignKey(b => b.RoleId);
        }
    }
}
