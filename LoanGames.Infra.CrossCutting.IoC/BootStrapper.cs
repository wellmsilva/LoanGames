using FluentValidation.Results;
using LoanGames.Application.Interfaces;
using LoanGames.Application.Services;
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

            services.AddSingleton<IMediatorHandler, InMemoryBus>();

            // Application
            services.AddScoped<IPersonAppService, PersonAppService>();

            // Domain - Events
            //services.AddScoped<INotificationHandler<CustomerRegisteredEvent>, CustomerEventHandler>();
            //services.AddScoped<INotificationHandler<CustomerUpdatedEvent>, CustomerEventHandler>();
            //services.AddScoped<INotificationHandler<CustomerRemovedEvent>, CustomerEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<NewPersonCommand, ValidationResult>, PersonCommandHandler>();
            services.AddScoped<IRequestHandler<UpdatePersonCommand, ValidationResult>, PersonCommandHandler>();
            services.AddScoped<IRequestHandler<RemovePersonCommand, ValidationResult>, PersonCommandHandler>();



            // Infra - Data
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<MainContext>();

            // Infra - Data EventSourcing
            //services.AddScoped<IEventStoreRepository, EventStoreSqlRepository>();
            //services.AddScoped<IEventStore, SqlEventStore>();
            //services.AddScoped<EventStoreSqlContext>();           


        }
    }
}
