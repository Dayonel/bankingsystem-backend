using BankingSystem.Data;
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
            services.AddDbContext<BankingSystemDbContext>(options => options.UseSqlServer(configuration.GetConnectionString(nameof(BankingSystemDbContext))));
            #endregion

            #region Hosted services
            services.AddHostedService<DbDataSeeder>();
            #endregion
        }
    }
}
