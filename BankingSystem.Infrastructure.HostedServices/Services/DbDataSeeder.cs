using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BankingSystem.Data;
using Microsoft.EntityFrameworkCore;
using BankingSystem.Core.Entity;
using Newtonsoft.Json;
using System.IO;

namespace BankingSystem.Infrastructure.HostedServices.Services
{
    public class DbDataSeeder : BackgroundService
    {
        private const string FakeDataFolderName = "FakeData";

        private readonly IServiceProvider _provider;
        public DbDataSeeder(IServiceProvider provider)
        {
            _provider = provider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Migrate();
            await SeedBanks();
            await SeedClients();
            await SeedAccountTypes();
            await SeedAccounts();
        }

        #region Migration
        private async Task Migrate()
        {
            using (var scope = _provider.CreateScope())
            {
                using (var _dbContext = scope.ServiceProvider.GetRequiredService<BankingSystemDbContext>())
                {
                    await _dbContext.Database.MigrateAsync();
                }
            }
        }
        #endregion

        #region Banks
        private async Task SeedBanks()
        {
            var banks = JsonConvert.DeserializeObject<List<Bank>>(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(),
                $"/{FakeDataFolderName}/fake-banks.json")));

            using (var scope = _provider.CreateScope())
            {
                using (var _dbContext = scope.ServiceProvider.GetRequiredService<BankingSystemDbContext>())
                {
                    if (!await _dbContext.Bank.AnyAsync())
                    {
                        _dbContext.Bank.AddRange(banks);
                        await _dbContext.SaveChangesAsync();
                    }
                }
            }
        }
        #endregion

        #region Clients
        private async Task SeedClients()
        {
            var clients = JsonConvert.DeserializeObject<List<Client>>(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(),
                $"/{FakeDataFolderName}/fake-clients.json")));

            using (var scope = _provider.CreateScope())
            {
                using (var _dbContext = scope.ServiceProvider.GetRequiredService<BankingSystemDbContext>())
                {
                    if (!await _dbContext.Client.AnyAsync())
                    {
                        _dbContext.Client.AddRange(clients);
                        await _dbContext.SaveChangesAsync();
                    }
                }
            }
        }
        #endregion

        #region Account types
        private async Task SeedAccountTypes()
        {
            var accountTypes = JsonConvert.DeserializeObject<List<AccountType>>(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(),
                $"/{FakeDataFolderName}/fake-accounttypes.json")));

            using (var scope = _provider.CreateScope())
            {
                using (var _dbContext = scope.ServiceProvider.GetRequiredService<BankingSystemDbContext>())
                {
                    if (!await _dbContext.AccountType.AnyAsync())
                    {
                        _dbContext.AccountType.AddRange(accountTypes);
                        await _dbContext.SaveChangesAsync();
                    }
                }
            }
        }
        #endregion

        #region Accounts
        private async Task SeedAccounts()
        {
            var accounts = JsonConvert.DeserializeObject<List<Account>>(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(),
                $"/{FakeDataFolderName}/fake-accounts.json")));

            using (var scope = _provider.CreateScope())
            {
                using (var _dbContext = scope.ServiceProvider.GetRequiredService<BankingSystemDbContext>())
                {
                    if (!await _dbContext.Account.AnyAsync())
                    {
                        _dbContext.Account.AddRange(accounts);
                        await _dbContext.SaveChangesAsync();
                    }
                }
            }
        }
        #endregion
    }
}
