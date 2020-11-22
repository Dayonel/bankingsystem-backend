using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace BankingSystem.Data.Factories
{
    public class BankingSystemDbContextContextFactory : IDesignTimeDbContextFactory<BankingSystemDbContext>
    {
        public BankingSystemDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<BankingSystemDbContext>();
#if DEBUG
            builder.UseSqlite("DataSource=bankingsystem.db",
#else
            builder.UseSqlite("DataSource=bankingsystem.db",
#endif
            opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(5).TotalSeconds));
            return new BankingSystemDbContext(builder.Options);
        }
    }
}
