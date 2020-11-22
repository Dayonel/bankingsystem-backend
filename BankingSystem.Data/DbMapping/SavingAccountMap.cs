using BankingSystem.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingSystem.Data.DbMapping
{
    public static class SavingAccountMap
    {
        public static ModelBuilder MapSavingAccounts(this ModelBuilder modelBuilder)
        {
            EntityTypeBuilder<SavingAccount> entity = modelBuilder.Entity<SavingAccount>();

            // Primary Key
            entity.HasKey(t => t.Id);

            // Relations
            entity.HasOne(p => p.Bank)
                  .WithMany(o => o.SavingAccounts)
                  .HasForeignKey(f => f.BankId);

            entity.HasOne(p => p.Client)
                  .WithMany(o => o.SavingAccounts)
                  .HasForeignKey(f => f.ClientId);

            return modelBuilder;
        }
    }
}
