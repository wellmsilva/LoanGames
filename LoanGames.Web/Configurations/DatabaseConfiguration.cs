using LoanGames.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;


namespace LoanGames.Web.Configurations
{
    public static class DatabaseConfiguration
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<MainContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

           
        }
    }
}
