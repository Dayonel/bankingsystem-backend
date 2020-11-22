using BankingSystem.Core.Entity.Base;
using BankingSystem.Core.Interfaces;
using System;

namespace BankingSystem.Core.Entity
{
    public class Account : EntityBase, ICreated
    {
        public int AccountNumber { get; set; }
        public float Balance { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual int BankId { get; set; }
        public virtual Bank Bank { get; set; }
        public virtual int ClientId { get; set; }
        public virtual Client Client { get; set; }
        public virtual int AccountTypeId { get; set; }
        public virtual AccountType AccountType { get; set; }
    }
}
