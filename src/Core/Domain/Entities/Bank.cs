using Domain.Abstractions;
using Domain.Enums;

namespace Domain.Entities
{
    public class Bank : Company
    {
        public uint CreditIds { get; set; }
        public uint ClientIds { get; set; }
        //public ICollection<BankAccount> Accounts { get; private set; }
        //public ICollection<IUser> Users { get; private set; }
    }
}
