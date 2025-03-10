using Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Dtos
{
    [Table("Companies")]
    internal class CompanyDto : EntityDto
    {
        public CompanyType Type { get; set; }
        public string LegalName { get; set; }
        public int TRN { get; set; }
        public int BIK { get; set; }
        public string LegalAddress { get; set; }
    }
}
