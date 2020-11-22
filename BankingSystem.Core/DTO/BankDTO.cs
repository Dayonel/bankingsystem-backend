using System.Collections.Generic;

namespace BankingSystem.Core.DTO
{
    public class BankDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }
        public string Address { get; set; }

        public List<AccountDTO> Accounts { get; set; } = new List<AccountDTO>();
    }
}
