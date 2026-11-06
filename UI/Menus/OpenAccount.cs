using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using GNET90_EFCORE04.Models;
using GNET90_EFCORE04.Models.Enums;
using GNET90_EFCORE04.Services;

namespace GNET90_EFCORE04.UI.Menus
{
    public class OpenAccount
    {
        public OpenAccountService _open { get; set; }
        public OpenAccount(OpenAccountService open)
        {
            _open = open;
        }
        public async Task run()
        {
            Console.Clear();
            Console.WriteLine($"------ Open Account ------");
            List<AccountType> accountType = [
                AccountType.Business,
                AccountType.Current,
                AccountType.FixedDeposit,
                AccountType.Salary,
                AccountType.Savings,
                AccountType.Student
            ];
            List<OwnerShipType> ownerShipType = [
                OwnerShipType.Single,
                OwnerShipType.Company,
                OwnerShipType.Joint,
                OwnerShipType.Trust,
                OwnerShipType.Custodial
            ];

            var AccNum = ConsoleInput.ReadInt("Account Number");
            ConsoleInput.readType(accountType, "Account Type", out AccountType type);
            int BCode = ConsoleInput.ReadInt("Branch Code");
            int CustomerCode = ConsoleInput.ReadInt("Customer ID");
            ConsoleInput.readType(ownerShipType, "OwnerShip Role", out OwnerShipType OwnerShip);


            if (!await _open.IsCustomerExists(CustomerCode))
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine($"Can not find The Customer");
                Console.ResetColor();
                return;
            }
            var newAccount = new Account
            {
                AccountNumber = AccNum,
                AccountType = type,
                BranchId = BCode,
                CustomerAccount = new List<CustomerAccount>
                {
                    new CustomerAccount{
                        CustomerId = CustomerCode,
                        OwnerShipType = OwnerShip,
                        OwnershipStartDate = DateTime.Now
                    }
                }
            };

            await _open.OpenNewAccount(newAccount);


        }
    }
}