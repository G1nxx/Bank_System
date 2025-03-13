using Domain.Primitives;
using Domain.Enums;

namespace Domain.Entities
{
    public class Company : Entity
    {
        public Company(uint Id, CompanyType type, string legalName, string legalAddress, int tRN, int bIK) : base(Id)
        {
            Type = type;
            LegalName = legalName;
            LegalAddress = legalAddress;
            TRN = tRN;
            BIK = bIK;
        } 

        public CompanyType Type { get; protected set; }
        public string LegalName { get; protected set; }
        public string LegalAddress { get; protected set; }
        public int TRN { get; protected set; }
        public int BIK { get; protected set; }

    }
}
