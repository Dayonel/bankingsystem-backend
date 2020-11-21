using Microsoft.EntityFrameworkCore;

namespace BankingSystem.Data
{
    public class BankingSystemDbContext : DbContext
    {
        public BankingSystemDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder) { }
    }
}
