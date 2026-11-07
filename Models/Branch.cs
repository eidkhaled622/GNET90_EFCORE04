using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GNET90_EFCORE04.Models
{
    public class Branch
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int ManagerId { get; set; }
        public Manager Manager { get; set; }
        public ICollection<Account> Accounts { get; set; }
    }
}