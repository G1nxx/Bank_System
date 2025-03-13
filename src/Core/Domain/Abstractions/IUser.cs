namespace Domain.Abstractions
{
    public interface IUser
    {
        public string Login { get; }
        public string Name { get;}
        public DateTime DateOfBirth { get; }
        public string Email { get; }
        public string PassportSeries { get; }
        public string PhoneNumber { get; }
    }
}
