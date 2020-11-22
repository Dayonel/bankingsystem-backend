using BankingSystem.Core.Entity;
using System.Threading.Tasks;

namespace BankingSystem.Core.Interfaces.Repository
{
    public interface IAccountTypeRepository
    {
        Task<AccountType> GetById(int id);
    }
}
