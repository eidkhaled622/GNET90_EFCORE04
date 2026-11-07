using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using GNET90_EFCORE04.Data;
using GNET90_EFCORE04.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace GNET90_EFCORE04.Services
{
    public class OpenAccountService
    {
        public AppDbContext _context { get; set; }
        public OpenAccountService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> IsCustomerExists(int id)
        {
            return await _context.Customers.AnyAsync(c => c.Id == id);
        }

        public async Task OpenNewAccount(Account newAccount)
        {
            try
            {

                await _context.Accounts.AddAsync(newAccount);
                await _context.SaveChangesAsync();
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine($"The Account Created Successfully");
                Console.ResetColor();
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
            }
        }


    }
}