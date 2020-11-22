using BankingSystem.Core.Entity.Base;
using BankingSystem.Core.Entity.Enum;

namespace BankingSystem.Core.Entity
{
    public class DepositAccount : Account
    {
        public int DepositPeriodInDays { get; set; }
        public InterestPayingFrequency InterestPayingFrequency { get; set; }
    }
}
