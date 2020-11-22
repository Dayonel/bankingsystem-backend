using BankingSystem.Core.Entity;
using System.Threading.Tasks;

namespace BankingSystem.Core.Interfaces.Repository
{
    public interface IClientRepository
    {
        Task<Client> GetById(int id);
    }
}
