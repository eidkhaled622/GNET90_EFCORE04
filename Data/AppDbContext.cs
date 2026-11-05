using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GNET90_EFCORE04.Configurations;
using GNET90_EFCORE04.Models;
using Microsoft.EntityFrameworkCore;

namespace GNET90_EFCORE04.Data
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=Bank-Management;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder ModelBuilder)
        {
            ModelBuilder.ApplyConfigurationsFromAssembly(typeof(BranchConfiguration).Assembly);
        }

        public DbSet<Branch> Branches { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Branch> Accounts { get; set; }
        public DbSet<Branch> Customers { get; set; }
        public DbSet<Branch> transactions { get; set; }
        public DbSet<CustomerAccount> CustomerAccounts { get; set; }
    }
}