using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security;
using System.Threading.Tasks;
using GNET90_EFCORE04.Data;
using GNET90_EFCORE04.Models;
using Microsoft.EntityFrameworkCore;

namespace GNET90_EFCORE04.Services
{
    public class AccountServices
    {
        private AppDbContext _context { get; set; }

        public AccountServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> IsCustomerLinkedToAccount(int customerId, int accountId)
        {
            return await _context.CustomerAccounts.FindAsync(customerId, accountId) is not null;
        }
        public async Task<int> addNewCustomer(Customer newCustomer)
        {
            await _context.Customers.AddAsync(newCustomer);
            await _context.SaveChangesAsync();
            return newCustomer.Id;
        }

        public async Task updateCustomer(CustomerAccount UpdatedAccount)
        {
            try
            {

                var link = await _context.CustomerAccounts.FindAsync(UpdatedAccount.CustomerId, UpdatedAccount.AccountId);

                link.AccountStatus = UpdatedAccount.AccountStatus;
                await _context.SaveChangesAsync();
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine($"Can not find The Customer");
                Console.ResetColor();
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
            }
        }

    }
}