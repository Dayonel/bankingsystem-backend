using BankingSystem.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingSystem.Data.DbMapping
{
    public static class DepositAccountMap
    {
        public static ModelBuilder MapDepositAccounts(this ModelBuilder modelBuilder)
        {
            EntityTypeBuilder<DepositAccount> entity = modelBuilder.Entity<DepositAccount>();

            // Primary Key
            entity.HasKey(t => t.Id);

            // Relations
            entity.HasOne(p => p.Bank)
                  .WithMany(o => o.DepositAccounts)
                  .HasForeignKey(f => f.BankId);

            entity.HasOne(p => p.Client)
                  .WithMany(o => o.DepositAccounts)
                  .HasForeignKey(f => f.ClientId);

            return modelBuilder;
        }
    }
}
