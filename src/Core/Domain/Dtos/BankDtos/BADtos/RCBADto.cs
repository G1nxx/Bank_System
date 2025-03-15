using Domain.Dtos.Base;
using SQLite;

namespace Domain.Dtos.BankDtos.BADtos
{
    [Table("RCBAs")]
    public class RCBADto : BABaseDto
    {
        [NotNull]
        public string IsApproved { get; set; }
    }
}
