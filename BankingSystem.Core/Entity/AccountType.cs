using BankingSystem.Core.Entity.Base;
using BankingSystem.Core.Entity.Enum;
using System.Collections.Generic;

namespace BankingSystem.Core.Entity
{
    public class AccountType : EntityBase
    {
        public AccountTypeEnum Type { get; set; }
        public float AnnualInterestRate { get; set; }
        public int? DepositPeriodInDays { get; set; }
        public InterestPayingFrequencyEnum? InterestPayingFrequency { get; set; }

        public virtual List<Account> Accounts { get; set; }
    }
}
