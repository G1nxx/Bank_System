using Domain.Primitives;
using Domain.Abstractions;

namespace Domain.Entities.Users
{
    internal class Client : Entity, IUser
    {
        public string Name { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public string PassportSeries { get; private set; }
    }
}
