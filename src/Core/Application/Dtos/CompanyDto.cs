using Domain.Enums;
using SQLite;

namespace Application.Dtos
{
    [Table("Companies")]
    public class CompanyDto : EntityDto
    {
        public string Type { get; set; }
        public string LegalName { get; set; }
        public int TRN { get; set; }
        public int BIK { get; set; }
        public string LegalAddress { get; set; }
    }
}
