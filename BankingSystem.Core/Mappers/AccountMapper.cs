using BankingSystem.Core.DTO;
using BankingSystem.Core.Entity;

namespace BankingSystem.Core.Mappers
{
    public static class AccountMapper
    {
        public static AccountDTO Map(this Account account)
        {
            return account != null
                ?
                new AccountDTO
                {
                    Id = account.Id,
                    AccountNumber = account.AccountNumber,
                    AccountType = account.AccountType.ToString(),
                    Balance = account.Balance
                }
                : null;
        }
    }
}
