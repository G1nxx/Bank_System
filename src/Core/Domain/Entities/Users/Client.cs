using Domain.Primitives;
using Domain.Abstractions;

namespace Domain.Entities.Users
{
    public class Client : Entity, IUser
    {
        public string Login { get; private set; }
        public string Name { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public string PassportSeries { get; private set; }
        public uint AccountId { get; private set; }
        public string Password { get; private set; }
    }
}
