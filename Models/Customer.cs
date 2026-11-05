using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GNET90_EFCORE04.Models.Enums;

namespace GNET90_EFCORE04.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public CustomerType CustomerType { get; set; }
        public string NationalId { get; set; }

        public ICollection<CustomerAccount> CustomerAccount { get; set; }

    }
}