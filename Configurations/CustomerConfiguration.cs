using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using GNET90_EFCORE04.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GNET90_EFCORE04.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).UseIdentityColumn(seed: 1000, increment: 1);

            builder.HasIndex(c => c.NationalId).IsUnique();

            builder.HasMany(c => c.CustomerAccount)
                    .WithOne(c => c.Customer)
                    .HasForeignKey(c => c.CustomerId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.Property(c => c.Address).IsRequired();
            builder.Property(c => c.DateOfBirth).IsRequired();
            builder.Property(c => c.Email).IsRequired();
            builder.Property(c => c.FullName).IsRequired().HasMaxLength(50);
            builder.Property(c => c.PhoneNumber).IsRequired();
        }
    }
}