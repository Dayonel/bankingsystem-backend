using BankingSystem.Core.Entity;
using BankingSystem.Data.DbMapping;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.Data
{
    public class BankingSystemDbContext : DbContext
    {
        public BankingSystemDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Bank> Bank { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<DepositAccount> DepositAccount { get; set; }
        public DbSet<SavingAccount> SavingAccount { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.MapBanks();
            builder.MapClients();
            builder.MapDepositAccounts();
            builder.MapSavingAccounts();
        }
    }
}
