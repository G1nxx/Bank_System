using Domain.Primitives;

namespace Domain.Entities
{
    public enum CompanyType
    {
        None,
        IP,
        OOO,
        OAO,
        ODO,
        ZAO
    }

    internal class Company : Entity
    {
        public CompanyType Type { get; private set; }
        public string LegalName { get; private set; }
        public int TRN { get; private set; }
        public int BIK { get; private set; }
        public string LegalAddress { get; private set; }

    }
}
