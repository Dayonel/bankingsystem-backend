using BankingSystem.Core.Constants;
using BankingSystem.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingSystem.Data.DbMapping
{
    public static class ClientMap
    {
        public static ModelBuilder MapClients(this ModelBuilder modelBuilder)
        {
            EntityTypeBuilder<Client> entity = modelBuilder.Entity<Client>();

            // Primary Key
            entity.HasKey(t => t.Id);

            // Relations
            entity.HasMany(p => p.DepositAccounts)
                  .WithOne(o => o.Client)
                  .HasForeignKey(f => f.ClientId);

            entity.HasMany(p => p.SavingAccounts)
                  .WithOne(o => o.Client)
                  .HasForeignKey(f => f.ClientId);

            // Length
            entity.Property(p => p.Name).HasMaxLength(PropertyConstants.DEFAULT_LENGTH);
            entity.Property(p => p.Address).HasMaxLength(PropertyConstants.LONG_LENGTH);

            return modelBuilder;
        }
    }
}
