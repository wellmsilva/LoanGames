using AutoMapper;
using FluentValidation.Results;
using LoanGames.Application.Interfaces;
using LoanGames.Application.ViewModels;
using LoanGames.Domain.Commands.PersonCommands;
using LoanGames.Domain.Interfaces.Repositories;
using LoanGames.Domain.Mediator;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoanGames.Application.Services
{
    public class PersonAppService : IPersonAppService
    {
        private readonly IMapper _mapper;
        private readonly IPersonRepository _personRepository;
        private readonly IMediatorHandler _mediator;


        public PersonAppService(IMapper mapper,
                                IPersonRepository personRepository,
                                IMediatorHandler mediator
            )
        {
            _mapper = mapper;
            _personRepository = personRepository;
            _mediator = mediator;
        }

        public async Task<ValidationResult> Add(PersonViewModel model)
        {
            var newCommand = _mapper.Map<NewPersonCommand>(model);
            return await _mediator.SendCommand(newCommand);
        }

        public async Task<IEnumerable<PersonViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<PersonViewModel>>(await _personRepository.GetAll());
        }

        public async Task<PersonViewModel> GetById(Guid id)
        {
            return _mapper.Map<PersonViewModel>(await _personRepository.GetById(id));
        }

        public async Task<PersonViewModel> GetByName(string name)
        {
            return _mapper.Map<PersonViewModel>(await _personRepository.GetByName(name));
        }

        public async Task<ValidationResult> Remove(Guid id)
        {
            var command = _mapper.Map<RemovePersonCommand>(id);
            return await _mediator.SendCommand(command);
        }

        public async Task<ValidationResult> Update(PersonViewModel model)
        {
            var command = _mapper.Map<UpdatePersonCommand>(model);
            return await _mediator.SendCommand(command);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
