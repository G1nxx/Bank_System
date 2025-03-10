using Domain.Abstractions;
using Domain.Primitives;

namespace Domain.Entities
{
    internal class Transfer : Entity
    {
        public BankAccount RecipientBankAccount { get; set; }
        public BankAccount ReceiverBankAccount { get; set; }
        public bool IsCancelled { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
    }
}
