using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GNET90_EFCORE04.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GNET90_EFCORE04.Configurations
{
    public class AccountConfigurations : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).UseIdentityColumn(seed: 1000, increment: 1);
            builder.HasIndex(a => a.AccountNumber).IsUnique();


            builder.Property(a => a.CurrentBalance).IsRequired();
            builder.Property(a => a.OpeningDate).IsRequired();
            builder.Property(a => a.BranchId).IsRequired();


            builder.HasOne(a => a.Branch)
                    .WithMany(a => a.Accounts)
                    .HasForeignKey(a => a.BranchId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(a => a.transactions)
                    .WithOne(a => a.Account)
                    .HasForeignKey(a => a.AccountId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(a => a.CustomerAccount)
                    .WithOne(a => a.Account)
                    .HasForeignKey(a => a.AccountId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}