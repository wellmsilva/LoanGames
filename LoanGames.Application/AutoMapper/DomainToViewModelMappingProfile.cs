﻿using AutoMapper;
using LoanGames.Application.ViewModels;
using LoanGames.Domain.Entities;

namespace LoanGames.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Person, PersonViewModel>();
        }
    }
}