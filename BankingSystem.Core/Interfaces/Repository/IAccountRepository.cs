using BankingSystem.Core.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankingSystem.Core.Interfaces.Repository
{
    public interface IAccountRepository
    {
        Task<Account> GetById(int id);
        Task<List<Account>> GetByClientId(int clientId);
        Task<bool> Update(Account account);
    }
}
