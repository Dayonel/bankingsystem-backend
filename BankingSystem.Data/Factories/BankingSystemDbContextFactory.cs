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
            builder.UseSqlServer("Server=localhost;Database=BankingSystem;User Id=sa;Password=.0]--2G!*t54tfzup^WUdoeDBw:5F3qcKHNW>+MU>Qer?R3u+XzR~1A@oMN.5J_%",
#else
            builder.UseSqlServer("Server=bankingsystemdb;Database=BankingSystem;User Id=sa;Password=.0]--2G!*t54tfzup^WUdoeDBw:5F3qcKHNW>+MU>Qer?R3u+XzR~1A@oMN.5J_%",
#endif
            opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(5).TotalSeconds));
            return new BankingSystemDbContext(builder.Options);
        }
    }
}
