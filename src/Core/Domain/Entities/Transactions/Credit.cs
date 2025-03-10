using Domain.Abstractions;
using Domain.Primitives;

namespace Domain.Entities.Transactions
{
    internal class Credit : Entity, IBankService
    {
        public decimal InterestRate { get; set; }

        public decimal Amount { get; set; }

        public DateTime LastUpdatedAt { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public DateTime ClosedAt { get; private set; }

        public int TermInMonths { get; private set; }

        public BankAccount Account { get; private set; }

        public bool IsApproved { get; private set; }
    }
}
