using BankingSystem.Core.Constants;
using BankingSystem.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingSystem.Data.DbMapping
{
    public static class BankMap
    {
        public static ModelBuilder MapBanks(this ModelBuilder modelBuilder)
        {
            EntityTypeBuilder<Bank> entity = modelBuilder.Entity<Bank>();

            // Primary Key
            entity.HasKey(t => t.Id);

            // Relations
            entity.HasMany(p => p.Accounts)
                  .WithOne(o => o.Bank)
                  .HasForeignKey(f => f.BankId);

            // Length
            entity.Property(p => p.Name).HasMaxLength(PropertyConstants.DEFAULT_LENGTH);
            entity.Property(p => p.Address).HasMaxLength(PropertyConstants.LONG_LENGTH);

            return modelBuilder;
        }
    }
}
