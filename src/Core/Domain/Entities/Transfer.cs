using Domain.Abstractions;
using Domain.Primitives;

namespace Domain.Entities
{
    public class Transfer : Entity
    {
        public Transfer(uint recipientBankAccountId, uint receiverBankAccountId, decimal amount) 
        {
            RecipientBankAccountId = recipientBankAccountId;
            ReceiverBankAccountId = receiverBankAccountId;
            Amount = amount;
            Date = DateTime.UtcNow;
            IsCancelled = false;
        }
        public uint RecipientBankAccountId { get; set; }
        public uint ReceiverBankAccountId { get; set; }
        public bool IsCancelled { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
    }
}
