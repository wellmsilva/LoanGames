using AutoMapper;
using LoanGames.Application.ViewModels;
using LoanGames.Domain.Commands.PersonCommands;

namespace LoanGames.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<PersonViewModel, NewPersonCommand>()
                .ConstructUsing(c => new NewPersonCommand(c.Name, c.Phone));
            CreateMap<PersonViewModel, UpdatePersonCommand>()
                .ConstructUsing(c => new UpdatePersonCommand(c.Id, c.Name, c.Phone));
        }
    }
}
