using BankingSystem.Core.DTO;
using BankingSystem.Core.Entity;

namespace BankingSystem.Core.Mappers
{
    public static class ClientMapper
    {
        public static ClientDTO Map(this Client client)
        {
            return client != null
                ?
                new ClientDTO
                {
                    Id = client.Id,
                    Name = client.Name,
                    Address = client.Address
                }
                : null;
        }
    }
}
