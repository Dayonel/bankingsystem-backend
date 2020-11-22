using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using BankingSystem.Core.Interfaces.Services;
using BankingSystem.Core.Extensions;

namespace BankingSystem.Controllers
{
    [ApiController]
    [Route("api/client")]
    public class ClientController
    {
        private readonly ILogger<ClientController> _logger;
        private readonly IClientService _clientService;
        public ClientController(ILogger<ClientController> logger, IClientService clientService)
        {
            _logger = logger;
            _clientService = clientService;
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> Get([Range(1, int.MaxValue, ErrorMessage = "Invalid client id.")] int id)
        {
            try
            {
                var result = await _clientService.GetById(id);
                return result.Success
                    ? new ObjectResult(result.Data)
                    : new ObjectResult(result.ErrorMessage) { StatusCode = StatusCodes.Status500InternalServerError };
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message());
                return new ObjectResult($"{nameof(Get)}-{nameof(ClientController)} request failed.") { StatusCode = StatusCodes.Status500InternalServerError };
            }
        }
    }
}
