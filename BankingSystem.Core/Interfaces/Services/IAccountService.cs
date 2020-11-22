using BankingSystem.Core.DTO;
using BankingSystem.Core.DTO.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankingSystem.Core.Interfaces.Services
{
    public interface IAccountService
    {
        Task<List<AccountDTO>> GetByClientId(int clientId);
        Task<BaseDTO<bool>> Deposit(int accountId, float amount);
        Task<BaseDTO<bool>> Withdraw(int accountId, float amount);
    }
}
