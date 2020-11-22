using BankingSystem.Core.DTO;
using BankingSystem.Core.DTO.Base;
using BankingSystem.Core.Interfaces.Repository;
using BankingSystem.Core.Interfaces.Services;
using BankingSystem.Core.Mappers;
using System.Threading.Tasks;

namespace BankingSystem.Core.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<BaseDTO<ClientDTO>> GetById(int id)
        {
            var result = new BaseDTO<ClientDTO>();

            var client = await _clientRepository.GetById(id);
            if (client == null)
            {
                result.AddError($"Client with id {id} not found.");
                return result;
            }

            result.Data = client.Map();
            return result;
        }
    }
}
