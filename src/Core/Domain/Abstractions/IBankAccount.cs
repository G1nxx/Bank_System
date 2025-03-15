using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions
{
    internal interface IBankAccount
    {
        public string AccountName { get; set; }
        public CurrencyType Currency { get; set; }
        public uint UserId { get; set; }
        public uint BankId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
