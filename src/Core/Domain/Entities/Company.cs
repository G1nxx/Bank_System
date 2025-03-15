using Domain.Primitives;
using Domain.Enums;

namespace Domain.Entities
{
    public class Company : Entity
    {
        public CompanyType Type { get; set; }
        public string LegalName { get; set; }
        public string LegalAddress { get; set; }
    }
}
