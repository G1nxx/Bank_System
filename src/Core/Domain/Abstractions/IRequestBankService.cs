namespace Domain.Abstractions
{
    internal interface IRequestBankService
    {
        public decimal InterestRate { get; }
        public int TermInMonths { get; }
        public string Message { get; }
    }
}
