using SQLite;

namespace Application.Dtos
{
    [Table("Users")]
    public class UserDto : EntityDto
    {
        [PrimaryKey, AutoIncrement, Indexed, NotNull]
        public uint Id { get; set; }

        [NotNull]
        public string Login { get; set; }
        public string Name { get; set; }

        [NotNull]
        public string Role { get; set; }
        public DateTime DateOfBirth { get; set; }

        [NotNull]
        public string Email { get; set; }
        public string PassportSeries { get; set; }
        public string PhoneNumber { get; set; }

        [NotNull]
        public string PasswordHash { get; set; }
    }
}
