using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GNET90_EFCORE04.Models;
using GNET90_EFCORE04.Models.Enums;
using GNET90_EFCORE04.Services;

namespace GNET90_EFCORE04.UI.Menus
{
    public class UpdateStatus
    {
        public AccountServices _account { get; set; }
        public UpdateStatus(AccountServices account)
        {
            _account = account;
        }

        public async Task run()
        {
            Console.Clear();
            Console.WriteLine($"------ Open Account ------");
            List<AccountStatus> accountStatus = [
                AccountStatus.Active,
                AccountStatus.Closed
            ];

            var AccNum = ConsoleInput.ReadInt("Account Number");
            var CustomerId = ConsoleInput.ReadInt("CustomerId");
            ConsoleInput.readType(accountStatus, "Account Status", out AccountStatus type);


            if (await _account.IsCustomerLinkedToAccount(CustomerId, AccNum))
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine($"Can not find The Relation");
                Console.ResetColor();
                return;
            }


            var newAccount = new CustomerAccount
            {
                AccountId = AccNum,
                CustomerId = CustomerId,
                AccountStatus = type
            };


            await _account.updateCustomer(newAccount);


        }
    }
}