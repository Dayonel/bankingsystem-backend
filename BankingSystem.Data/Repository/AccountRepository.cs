using BankingSystem.Core.Entity;
using BankingSystem.Core.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingSystem.Data.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BankingSystemDbContext _dbContext;
        public AccountRepository(BankingSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Account> GetById(int id)
        {
            return await _dbContext.Account.FindAsync(id);
        }

        public async Task<List<Account>> GetByClientId(int clientId)
        {
            return await _dbContext.Account
                .Where(b => b.ClientId == clientId)
                .ToListAsync();
        }

        public async Task<bool> Update(Account account)
        {
            var dbAccount = await _dbContext.Account.FindAsync(account.Id);

            dbAccount.Balance = account.Balance;

            _dbContext.Account.Update(dbAccount);
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
