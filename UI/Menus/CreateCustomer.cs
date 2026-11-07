using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using GNET90_EFCORE04.Models;
using GNET90_EFCORE04.Models.Enums;
using GNET90_EFCORE04.Services;
using Microsoft.VisualBasic;

namespace GNET90_EFCORE04.UI.Menus
{
    public class CreateCustomer
    {
        private AccountServices _account { get; set; }
        public CreateCustomer(AccountServices account)
        {
            _account = account;
        }

        public async Task run()
        {
            Console.Clear();
            Console.WriteLine($"------ Add Customer ------");
            List<CustomerType> customerType = [
                CustomerType.Individual,
                CustomerType.Government,
                CustomerType.Corporate,
                CustomerType.SmallBusiness,
                CustomerType.NonProfit
            ];
            ConsoleInput.ReadString("Full Name", out string fullName);
            ConsoleInput.ReadString("National ID", out string NID);
            ConsoleInput.ReadString("Date Of Birth (yyyy-mm-dd)", out string BirthDate);
            ConsoleInput.ReadString("Email", out string Email);
            ConsoleInput.ReadString("Phone", out string Phone);
            ConsoleInput.ReadString("Address", out string Address);

            ConsoleInput.readType(customerType, "Customer Type", out CustomerType type);

            var newCustomer = new Customer
            {
                FullName = fullName,
                NationalId = NID,
                DateOfBirth = DateTime.Parse(BirthDate),
                Email = Email,
                PhoneNumber = Phone,
                Address = Address,
                CustomerType = type
            };

            int id = await _account.addNewCustomer(newCustomer);

            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine($"CustomerCreated Successfully , CustomerId = {id}");
            Console.ResetColor();
        }
    }
}