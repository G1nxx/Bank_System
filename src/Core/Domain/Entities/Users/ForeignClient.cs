namespace Domain.Entities.Users
{
    internal class ForeignClient : Client
    {
        public string Policy { get; private set; }
        public string RegistrationId { get; private set; }
    }
}
