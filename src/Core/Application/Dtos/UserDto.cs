using SQLite;

namespace Application.Dtos
{
    [Table("Users")]
    public class UserDto : EntityDto
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PassportSeries { get; set; }
        public string PhoneNumber { get; set; }
    }
}
