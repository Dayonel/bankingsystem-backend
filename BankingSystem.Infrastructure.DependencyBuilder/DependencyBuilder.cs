using BankingSystem.Core.Interfaces.Repository;
using BankingSystem.Core.Interfaces.Services;
using BankingSystem.Core.Services;
using BankingSystem.Data;
using BankingSystem.Data.Repository;
using BankingSystem.Infrastructure.HostedServices.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BankingSystem.Infrastructure.DependencyBuilder
{
    public static class DependencyBuilder
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            #region DB
            services.AddDbContext<BankingSystemDbContext>(options => options.UseSqlite(configuration.GetConnectionString(nameof(BankingSystemDbContext))));
            #endregion

            #region Services
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IClientService, ClientService>();
            #endregion

            #region Repositories
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IAccountTypeRepository, AccountTypeRepository>();
            services.AddTransient<IClientRepository, ClientRepository>();
            #endregion

            #region Hosted services
            services.AddHostedService<DbDataSeeder>();
            #endregion
        }
    }
}
