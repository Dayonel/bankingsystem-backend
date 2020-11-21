namespace BankingSystem.Core.Entity.Base
{
    public abstract class Account : EntityBase
    {
        public int AccountNumber { get; set; }
        public float Balance { get; set; }
        public float AnnualInterestRate { get; set; }

        public virtual int BankId { get; set; }
        public virtual Bank Bank { get; set; }
        public virtual int ClientId { get; set; }
        public virtual Client Client { get; set; }
    }
}
