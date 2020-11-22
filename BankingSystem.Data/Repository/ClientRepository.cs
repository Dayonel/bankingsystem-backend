using BankingSystem.Core.Entity;
using BankingSystem.Core.Interfaces.Repository;
using System.Threading.Tasks;

namespace BankingSystem.Data.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly BankingSystemDbContext _dbContext;
        public ClientRepository(BankingSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Client> GetById(int id)
        {
            return await _dbContext.Client.FindAsync(id);
        }
    }
}
