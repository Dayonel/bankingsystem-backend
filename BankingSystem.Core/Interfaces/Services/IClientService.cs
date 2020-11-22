using BankingSystem.Core.DTO;
using BankingSystem.Core.DTO.Base;
using System.Threading.Tasks;

namespace BankingSystem.Core.Interfaces.Services
{
    public interface IClientService
    {
        Task<BaseDTO<ClientDTO>> GetById(int id);
    }
}
