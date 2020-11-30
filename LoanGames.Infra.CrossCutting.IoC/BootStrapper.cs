using FluentValidation.Results;
using LoanGames.Application.Interfaces;
using LoanGames.Application.Services;
using LoanGames.Domain.Commands.GameCommands;
using LoanGames.Domain.Commands.LoanCommands;
using LoanGames.Domain.Commands.PersonCommands;
using LoanGames.Domain.Interfaces.Repositories;
using LoanGames.Domain.Mediator;
using LoanGames.Infra.CrossCutting.Bus;
using LoanGames.Infra.Data.Contexts;
using LoanGames.Infra.Data.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace LoanGames.Infra.CrossCutting.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, InMemoryBus>();
            RegisterApplication(services);    
            RegisterDomainCommands(services);
            RegisterInfraData(services); 
            services.AddMediatR(typeof(BootStrapper));
        }

        private static void RegisterInfraData(IServiceCollection services)
        {
            services.AddScoped<ILoanRepository, LoanRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<MainContext>();
        }

        private static void RegisterDomainCommands(IServiceCollection services)
        {
            // Person
            services.AddScoped<IRequestHandler<NewPersonCommand, ValidationResult>, PersonCommandHandler>();
            services.AddScoped<IRequestHandler<UpdatePersonCommand, ValidationResult>, PersonCommandHandler>();
            services.AddScoped<IRequestHandler<RemovePersonCommand, ValidationResult>, PersonCommandHandler>();
            // Game
            services.AddScoped<IRequestHandler<NewGameCommand, ValidationResult>, GameCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateGameCommand, ValidationResult>, GameCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveGameCommand, ValidationResult>, GameCommandHandler>();
            // Loan
           services.AddScoped<IRequestHandler<RegisterLoanCommand, ValidationResult>, LoanCommandHandler>();
            services.AddScoped<IRequestHandler<GiveBackLoanCommand, ValidationResult>, LoanCommandHandler>();

        }

        private static void RegisterApplication(IServiceCollection services)
        {
            services.AddScoped<IUserAppService, UserAppService>();
            services.AddScoped<IPersonAppService, PersonAppService>();
            services.AddScoped<IGameAppService, GameAppService>();
            services.AddScoped<ILoanAppService, LoanAppService>();
        }

    }
}
