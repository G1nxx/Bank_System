using Domain.Abstractions;
using Domain.Primitives;

namespace Domain.Entities
{
    internal class BankAccount : Entity
    {
        public bool IsLocked { get; private set; }
        public decimal Amount { get; private set; }
        public IEnumerable<IBankService> Services { get; private set; }
    }
}
