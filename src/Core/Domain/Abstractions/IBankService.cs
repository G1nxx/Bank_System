using Domain.Entities;

namespace Domain.Abstractions
{
    public interface IBankService
    {
        public decimal InterestRate { get; }
        public decimal Amount { get; }
        public DateTime LastUpdatedAt { get; }
        public DateTime CreatedAt { get; }
        public DateTime ClosedAt { get; }
        public int TermInMonths { get; }
        public BankAccount Account { get; }
        public bool IsApproved { get;  }
    }
}
