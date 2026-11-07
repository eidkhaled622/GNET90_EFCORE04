using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using GNET90_EFCORE04.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace GNET90_EFCORE04.Models
{
    [Index(nameof(TransactionNumber), IsUnique = true)]
    public class Transaction
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int TransactionNumber { get; set; }
        [Required]
        public DateTime TransactionDate { get; set; }
        [Required]
        public decimal Amount { get; set; }
        public TransactionType TransactionType { get; set; }
        [Required]
        public string Note { get; set; }

        // ForeignKey
        [Required]
        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}