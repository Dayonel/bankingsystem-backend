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
        public DbSet<Account> Account { get; set; }
        public DbSet<AccountType> AccountType { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.MapBanks();
            builder.MapClients();
            builder.MapAccounts();
            builder.MapAccountTypes();
        }
    }
}
