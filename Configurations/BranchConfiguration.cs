using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GNET90_EFCORE04.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GNET90_EFCORE04.Configurations
{
    public class BranchConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id).UseIdentityColumn(seed: 1000, increment: 1);

            builder.HasIndex(b => b.Code).IsUnique();

            builder.Property(b => b.Code).IsRequired();
            builder.Property(b => b.Name).IsRequired();
            builder.Property(b => b.Address).IsRequired();
            builder.Property(b => b.PhoneNumber).IsRequired();

            builder.HasOne(b => b.Manager)
            .WithOne(b => b.Branch)
            .HasForeignKey<Branch>(b => b.ManagerId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}