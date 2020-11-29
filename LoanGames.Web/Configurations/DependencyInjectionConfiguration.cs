using LoanGames.Infra.CrossCutting.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace LoanGames.Web.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            BootStrapper.RegisterServices(services);
        }
    }
}
