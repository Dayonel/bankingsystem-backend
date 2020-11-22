using BankingSystem.Core.Entity;
using BankingSystem.Core.Entity.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BankingSystem.Data.DbMapping
{
    public static class AccountTypeMap
    {
        public static ModelBuilder MapAccountTypes(this ModelBuilder modelBuilder)
        {
            EntityTypeBuilder<AccountType> entity = modelBuilder.Entity<AccountType>();

            // Primary Key
            entity.HasKey(t => t.Id);

            // Relations
            entity.HasMany(p => p.Accounts)
                  .WithOne(o => o.AccountType)
                  .HasForeignKey(f => f.AccountTypeId);

            // Properties
            entity.Property(p => p.Type).HasConversion(new EnumToStringConverter<AccountTypeEnum>()).IsUnicode(false);

            return modelBuilder;
        }
    }
}
