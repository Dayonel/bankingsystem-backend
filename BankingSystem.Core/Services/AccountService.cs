using BankingSystem.Core.DTO;
using BankingSystem.Core.DTO.Base;
using BankingSystem.Core.Entity.Enum;
using BankingSystem.Core.Interfaces.Repository;
using BankingSystem.Core.Interfaces.Services;
using BankingSystem.Core.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingSystem.Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IAccountTypeRepository _accountTypeRepository;
        public AccountService(IAccountRepository accountRepository, IAccountTypeRepository accountTypeRepository)
        {
            _accountRepository = accountRepository;
            _accountTypeRepository = accountTypeRepository;
        }

        public async Task<List<AccountDTO>> GetByClientId(int clientId)
        {
            return (await _accountRepository.GetByClientId(clientId)).Select(s => s.Map()).ToList();
        }

        public async Task<BaseDTO<bool>> Deposit(int accountId, float amount)
        {
            var result = new BaseDTO<bool>();

            var account = await _accountRepository.GetById(accountId);
            if (account == null)
            {
                result.AddError($"Account {accountId} not found");
                return result;
            }

            account.Balance += amount;
            result.Data = await _accountRepository.Update(account);

            return result;
        }

        public async Task<BaseDTO<bool>> Withdraw(int accountId, float amount)
        {
            var result = new BaseDTO<bool>();

            var account = await _accountRepository.GetById(accountId);
            if (account == null)
            {
                result.AddError($"Account {accountId} not found");
                return result;
            }

            if (amount > account.Balance)
            {
                result.AddError("Insufficient balance.");
                return result;
            }

            var accountType = await _accountTypeRepository.GetById(account.AccountTypeId);
            if (accountType.Type == AccountTypeEnum.DepositAccount)
            {
                if ((DateTime.UtcNow.Date - account.DateCreated.Date).TotalDays < accountType.DepositPeriodInDays)
                {
                    result.AddError("Withdraw can be made only at maturity.");
                    return result;
                }
            }

            account.Balance -= amount;
            result.Data = await _accountRepository.Update(account);

            return result;
        }
    }
}
