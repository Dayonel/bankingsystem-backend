using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using BankingSystem.Core.Interfaces.Services;
using BankingSystem.Core.Extensions;
using BankingSystem.VM.Request;

namespace BankingSystem.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IAccountService _accountService;
        public AccountController(ILogger<AccountController> logger, IAccountService accountService)
        {
            _logger = logger;
            _accountService = accountService;
        }

        [HttpGet, Route("{clientId}")]
        public async Task<IActionResult> GetByClientId([Range(1, int.MaxValue, ErrorMessage = "Invalid client id.")] int clientId)
        {
            try
            {
                return new ObjectResult(await _accountService.GetByClientId(clientId));
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message());
                return new ObjectResult($"{nameof(GetByClientId)}-{nameof(AccountController)} request failed.") { StatusCode = StatusCodes.Status500InternalServerError };
            }
        }

        [HttpPost, Route("deposit")]
        public async Task<IActionResult> Deposit([FromBody] DepositVM depositVM)
        {
            try
            {
                var result = await _accountService.Deposit(depositVM.AccountId, depositVM.Amount);
                return result.Success
                    ? new ObjectResult(result.Data)
                    : new ObjectResult(result.ErrorMessage) { StatusCode = StatusCodes.Status500InternalServerError };
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message());
                return new ObjectResult($"{nameof(Deposit)}-{nameof(AccountController)} request failed.") { StatusCode = StatusCodes.Status500InternalServerError };
            }
        }

        [HttpPost, Route("withdraw")]
        public async Task<IActionResult> Withdraw([FromBody] WithdrawVM withdrawVM)
        {
            try
            {
                var result = await _accountService.Withdraw(withdrawVM.AccountId, withdrawVM.Amount);
                return result.Success
                    ? new ObjectResult(result.Data)
                    : new ObjectResult(result.ErrorMessage) { StatusCode = StatusCodes.Status500InternalServerError };
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message());
                return new ObjectResult($"{nameof(Withdraw)}-{nameof(AccountController)} request failed.") { StatusCode = StatusCodes.Status500InternalServerError };
            }
        }
    }
}
