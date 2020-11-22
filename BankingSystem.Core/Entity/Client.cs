using BankingSystem.Core.Entity.Base;
using System.Collections.Generic;

namespace BankingSystem.Core.Entity
{
    public class Client : EntityBase
    {
        public string Name { get; set; }
        public string Address { get; set; }

        public virtual List<Account> Accounts { get; set; }
    }
}
