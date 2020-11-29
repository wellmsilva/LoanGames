using LoanGames.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using AutoMapper;

namespace LoanGames.Web.Configurations
{
    public static class AutoMapperConfiguration
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(DomainToViewModelMappingProfile), typeof(ViewModelToDomainMappingProfile));
        }
    }
}
