namespace BankingSystem.Core.DTO
{
    public class DepositAccountDTO
    {
        public int Id { get; set; }
        public int AccountNumber { get; set; }
        public float Balance { get; set; }
        public float AnnualInterestRate { get; set; }
        public int DepositPeriodInDays { get; set; }
        public string InterestPayingFrequency { get; set; }
    }
}
