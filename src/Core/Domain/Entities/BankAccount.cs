using Domain.Abstractions;
using Domain.Enums;
using Domain.Primitives;

namespace Domain.Entities
{
    public class BankAccount : Entity, IBankAccount
    {
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public CurrencyType Currency { get; set; }
        public AStatusType Status { get; set; }
        public uint UserId { get; set; }
        public uint BankId { get; set; }
        public DateTime CreatedAt { get; set; }
        public BankAccount(string accountName, CurrencyType currency, uint userId, uint bankId)
        {
            AccountName = accountName;
            Currency = currency;
            UserId = userId;
            BankId = bankId;
            CreatedAt = DateTime.UtcNow;
            AccountNumber = GenerateAccountNumber();
            Balance = 0;
        }
        public BankAccount(RCBA rcba)
        {
            AccountName = rcba.AccountName;
            Currency = rcba.Currency;
            UserId = rcba.UserId;
            BankId = rcba.BankId;
            CreatedAt = DateTime.UtcNow;
            AccountNumber = GenerateAccountNumber();
            Balance = 0;
        }
        private string GenerateAccountNumber()
        {
            var random = new Random();
            return $"{DateTime.UtcNow:yyyyMMdd}-{random.Next(1000, 9999)}";
        }
    }
}
