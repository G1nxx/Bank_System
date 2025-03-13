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

        public CompanyType Type { get; set; }
        public string LegalName { get; set; }
        public string LegalAddress { get; set; }
        public int TRN { get; set; }
        public int BIK { get; set; }

    }
}
