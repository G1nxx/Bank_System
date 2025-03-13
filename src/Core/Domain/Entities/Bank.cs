using Domain.Abstractions;
using Domain.Enums;

namespace Domain.Entities
{
    public class Bank : Company
    {
        public Bank(
            uint Id,
            CompanyType Type,
            string LegalName,
            string LegalAddress,
                int TRN,
                int BIK,
            uint CreditIds,
            uint ClientIds) : base(Id, Type, LegalName, LegalAddress, TRN, BIK)
        {
            this.CreditIds = CreditIds;
            this.ClientIds = ClientIds;
        } 
        public uint CreditIds { get; set; }
        public uint ClientIds { get; set; }
        //public ICollection<BankAccount> Accounts { get; private set; }
        //public ICollection<IUser> Users { get; private set; }
    }
}
