namespace Domain.Abstractions
{
    public interface IUser
    {
        public uint Id { get; }
        public string Login { get; }
        public string Name { get; }
        public string Role { get; }
        public DateTime DateOfBirth { get; }
        public string Email { get; }
        public string PassportSeries { get; }
        public string PhoneNumber { get; }
        public string PasswordHash { get; set; }
    }
}
