using BankingSystem.Core.Entity;
using BankingSystem.Core.Interfaces.Repository;
using System.Threading.Tasks;

namespace BankingSystem.Data.Repository
{
    public class AccountTypeRepository : IAccountTypeRepository
    {
        private readonly BankingSystemDbContext _dbContext;
        public AccountTypeRepository(BankingSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AccountType> GetById(int id)
        {
            return await _dbContext.AccountType.FindAsync(id);
        }
    }
}
