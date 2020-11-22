using BankingSystem.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingSystem.Data.DbMapping
{
    public static class AccountMap
    {
        public static ModelBuilder MapAccounts(this ModelBuilder modelBuilder)
        {
            EntityTypeBuilder<Account> entity = modelBuilder.Entity<Account>();

            // Primary Key
            entity.HasKey(t => t.Id);

            // Relations
            entity.HasOne(p => p.Bank)
                  .WithMany(o => o.Accounts)
                  .HasForeignKey(f => f.BankId);

            entity.HasOne(p => p.Client)
                  .WithMany(o => o.Accounts)
                  .HasForeignKey(f => f.ClientId);

            return modelBuilder;
        }
    }
}
