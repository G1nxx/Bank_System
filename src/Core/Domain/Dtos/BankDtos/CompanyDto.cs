using Domain.Dtos.BaseDtos;
using Domain.Enums;
using SQLite;

namespace Domain.Dtos.BankDtos
{
    [Table("Companies")]
    public class CompanyDto : EntityDto
    {
        public string Type { get; set; }
        public string LegalName { get; set; }
        public string LegalAddress { get; set; }
    }
}
