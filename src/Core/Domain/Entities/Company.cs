using Domain.Primitives;
using Domain.Enums;

namespace Domain.Entities
{
    public class Company : Entity
    {
        public CompanyType Type { get; protected set; }
        public string LegalName { get; protected set; }
        public int TRN { get; protected set; }
        public int BIK { get; protected set; }
        public string LegalAddress { get; protected set; }

    }
}
