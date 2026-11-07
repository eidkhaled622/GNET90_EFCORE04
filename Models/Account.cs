using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GNET90_EFCORE04.Models
{
    public class Account
    {
        public int Id { get; set; }
        public int AccountNumber { get; set; }
        public decimal CurrentBalance { get; set; }
        public AccountType AccountType { get; set; }
        public DateTime OpeningDate { get; set; }

        public ICollection<Transaction> transactions { get; set; }

        // foreignKey
        public int BranchId { get; set; }
        public Branch Branch { get; set; }

        public ICollection<CustomerAccount> CustomerAccount { get; set; }
    }
}