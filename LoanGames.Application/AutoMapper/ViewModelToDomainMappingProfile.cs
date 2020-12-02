using AutoMapper;
using LoanGames.Application.InputModels;
using LoanGames.Application.ViewModels;
using LoanGames.Domain.Commands.GameCommands;
using LoanGames.Domain.Commands.LoanCommands;
using LoanGames.Domain.Commands.PersonCommands;

namespace LoanGames.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            // Person
            CreateMap<PersonViewModel, NewPersonCommand>()
                .ConstructUsing(c => new NewPersonCommand(c.Name, c.Phone));
            CreateMap<PersonViewModel, UpdatePersonCommand>()
                .ConstructUsing(c => new UpdatePersonCommand(c.Id, c.Name, c.Phone));

            // Game
            CreateMap<GameViewModel, NewGameCommand>()
                .ConstructUsing(c => new NewGameCommand(c.Name));
            CreateMap<GameViewModel, UpdateGameCommand>()
                .ConstructUsing(c => new UpdateGameCommand(c.Id, c.Name));

            //

            CreateMap<LoanInputModel, GiveBackLoanCommand>()
                .ConstructUsing(c => new GiveBackLoanCommand(c.Game_Id, c.Person_Id));

            CreateMap<LoanInputModel, RegisterLoanCommand>()
                .ConstructUsing(c => new RegisterLoanCommand(c.Game_Id, c.Person_Id));
        }
    }
}
