using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GNET90_EFCORE04.Data;
using GNET90_EFCORE04.Models;
using GNET90_EFCORE04.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace GNET90_EFCORE04
{
    public class DataSeed
    {
        public static void Seed(AppDbContext context)
        {
            if (context.Set<Branch>().Any())
            {
                return;
            }

            using var transaction = context.Database.BeginTransaction();

            var managers = new[]
            {
                new Manager
                {
                    FullName = "Mariam Hassan",
                    Email = "mariam.hassan@demo-bank.com",
                    PhoneNumber = "+1-555-0101",
                    HireDate = "2018-03-15"
                },
                new Manager
                {
                    FullName = "Omar Khaled",
                    Email = "omar.khaled@demo-bank.com",
                    PhoneNumber = "+1-555-0102",
                    HireDate = "2020-07-01"
                }
            };

            context.Set<Manager>().AddRange(managers);
            context.SaveChanges();

            var branches = new[]
            {
                new Branch
                {
                    Code = "BR-001",
                    Name = "Downtown Branch",
                    Address = "100 Main Street",
                    PhoneNumber = "+1-555-1001",
                    ManagerId = managers[0].Id,
                    Manager = managers[0]
                },
                new Branch
                {
                    Code = "BR-002",
                    Name = "Riverside Branch",
                    Address = "200 River Avenue",
                    PhoneNumber = "+1-555-1002",
                    ManagerId = managers[1].Id,
                    Manager = managers[1]
                }
            };

            context.Set<Branch>().AddRange(branches);
            context.SaveChanges();

            for (var index = 0; index < managers.Length; index++)
            {
                managers[index].BranchID = branches[index].Id;
            }

            var accounts = new[]
            {
                new Account
                {
                    AccountNumber = 10000001,
                    CurrentBalance = 5250.75m,
                    AccountType = AccountType.Savings,
                    OpeningDate = new DateTime(2023, 1, 15),
                    Branch = branches[0]
                },
                new Account
                {
                    AccountNumber = 10000002,
                    CurrentBalance = 12800.00m,
                    AccountType = AccountType.Current,
                    OpeningDate = new DateTime(2022, 8, 3),
                    Branch = branches[0]
                },
                new Account
                {
                    AccountNumber = 20000001,
                    CurrentBalance = 31750.50m,
                    AccountType = AccountType.FixedDeposit,
                    OpeningDate = new DateTime(2024, 2, 20),
                    Branch = branches[1]
                }
            };

            var customers = new[]
            {
                new Customer
                {
                    Address = "12 Cedar Lane",
                    DateOfBirth = new DateTime(1990, 4, 12),
                    FullName = "Lina Ahmed",
                    Email = "lina.ahmed@example.com",
                    PhoneNumber = "+1-555-2001",
                    CustomerType = CustomerType.Individual,
                    NationalId = "DEMO-NID-1001"
                },
                new Customer
                {
                    Address = "48 Oak Avenue",
                    DateOfBirth = new DateTime(1985, 11, 6),
                    FullName = "Youssef Samir",
                    Email = "youssef.samir@example.com",
                    PhoneNumber = "+1-555-2002",
                    CustomerType = CustomerType.Individual,
                    NationalId = "DEMO-NID-1002"
                },
                new Customer
                {
                    Address = "300 Market Street",
                    DateOfBirth = new DateTime(2000, 6, 25),
                    FullName = "Nile Books LLC",
                    Email = "accounts@nilebooks.example",
                    PhoneNumber = "+1-555-2003",
                    CustomerType = CustomerType.SmallBusiness,
                    NationalId = "DEMO-NID-1003"
                }
            };

            context.Set<Account>().AddRange(accounts);
            context.Set<Customer>().AddRange(customers);

            context.Set<CustomerAccount>().AddRange(
                new CustomerAccount
                {
                    Account = accounts[0],
                    Customer = customers[0],
                    OwnerShipType = OwnerShipType.Single,
                    AccountStatus = AccountStatus.Active,
                    OwnershipStartDate = new DateTime(2023, 1, 15)
                },
                new CustomerAccount
                {
                    Account = accounts[1],
                    Customer = customers[0],
                    OwnerShipType = OwnerShipType.Joint,
                    AccountStatus = AccountStatus.Active,
                    OwnershipStartDate = new DateTime(2023, 5, 10)
                },
                new CustomerAccount
                {
                    Account = accounts[1],
                    Customer = customers[1],
                    OwnerShipType = OwnerShipType.Joint,
                    AccountStatus = AccountStatus.Active,
                    OwnershipStartDate = new DateTime(2023, 5, 10)
                },
                new CustomerAccount
                {
                    Account = accounts[2],
                    Customer = customers[2],
                    OwnerShipType = OwnerShipType.Company,
                    AccountStatus = AccountStatus.Active,
                    OwnershipStartDate = new DateTime(2024, 2, 20)
                });

            context.Set<Transaction>().AddRange(
                new Transaction
                {
                    TransactionNumber = 900001,
                    TransactionDate = new DateTime(2024, 2, 20, 9, 0, 0),
                    Amount = 5000.00m,
                    TransactionType = TransactionType.Deposit,
                    Note = "Initial deposit",
                    Account = accounts[0]
                },
                new Transaction
                {
                    TransactionNumber = 900002,
                    TransactionDate = new DateTime(2024, 3, 1, 14, 30, 0),
                    Amount = 250.00m,
                    TransactionType = TransactionType.Withdrawal,
                    Note = "ATM withdrawal",
                    Account = accounts[0]
                },
                new Transaction
                {
                    TransactionNumber = 900003,
                    TransactionDate = new DateTime(2024, 3, 2, 11, 15, 0),
                    Amount = 1200.00m,
                    TransactionType = TransactionType.Deposit,
                    Note = "Salary payment",
                    Account = accounts[1]
                },
                new Transaction
                {
                    TransactionNumber = 900004,
                    TransactionDate = new DateTime(2024, 4, 5, 10, 0, 0),
                    Amount = 50.00m,
                    TransactionType = TransactionType.Fee,
                    Note = "Monthly account fee",
                    Account = accounts[1]
                },
                new Transaction
                {
                    TransactionNumber = 900005,
                    TransactionDate = new DateTime(2024, 4, 10, 16, 45, 0),
                    Amount = 2500.00m,
                    TransactionType = TransactionType.Deposit,
                    Note = "Business revenue",
                    Account = accounts[2]
                });

            context.SaveChanges();
            transaction.Commit();
        }
    }
}