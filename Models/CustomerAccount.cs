using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using GNET90_EFCORE04.Models.Enums;

namespace GNET90_EFCORE04.Models
{
    public class CustomerAccount
    {
        [Key]
        public int Id { get; set; }
        public OwnerShipType OwnerShipType { get; set; }
        public AccountStatus AccountStatus { get; set; }
        public DateTime OwnershipStartDate { get; set; }

        public int AccountId { get; set; }
        public Account Account { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}