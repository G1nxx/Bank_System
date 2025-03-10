using Domain.Abstractions;

namespace Domain.Entities
{
    internal class Bank() : Company
    {
        public IEnumerable<BankAccount> Credits { get; private set; }
        public IEnumerable<IUser> Clients { get; private set; }
    }
}
