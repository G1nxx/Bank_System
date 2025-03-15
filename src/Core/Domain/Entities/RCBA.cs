using Domain.Abstractions;
using Domain.Enums;
using Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class RCBA : Entity, IBankAccount
    {
        public RCBA(string accountName, CurrencyType currency, uint userId, uint bankId)
        {
            AccountName = accountName;
            Currency = currency;
            UserId = userId;
            BankId = bankId;
            IsApproved = RStatusType.InProcess;
            CreatedAt = DateTime.UtcNow;
        }

        public string AccountName { get; set; }
        public CurrencyType Currency { get; set; }
        public uint UserId { get; set; }
        public uint BankId { get; set; }
        public RStatusType IsApproved { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
