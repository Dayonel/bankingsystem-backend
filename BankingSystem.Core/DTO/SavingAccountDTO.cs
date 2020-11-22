namespace BankingSystem.Core.DTO
{
    public class SavingAccountDTO
    {
        public int Id { get; set; }
        public int AccountNumber { get; set; }
        public float Balance { get; set; }
        public float AnnualInterestRate { get; set; }
    }
}
