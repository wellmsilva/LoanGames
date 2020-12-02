using AutoMapper;
using LoanGames.Application.ViewModels;
using LoanGames.Domain.Entities;

namespace LoanGames.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Person, PersonViewModel>();
            CreateMap<Game, GameViewModel>();
            CreateMap<Loan, LoanViewModel>()
                .ForMember( dest => dest.Person, map => map.MapFrom(o => o.Person.Name))
                .ForMember( dest => dest.Game, map => map.MapFrom(o => o.Game.Name));

            CreateMap<User, UserViewModel>();
        }
    }
}
