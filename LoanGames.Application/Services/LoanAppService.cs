using AutoMapper;
using FluentValidation.Results;
using LoanGames.Application.InputModels;
using LoanGames.Application.Interfaces;
using LoanGames.Application.ViewModels;
using LoanGames.Domain.Commands.LoanCommands;
using LoanGames.Domain.Interfaces.Repositories;
using LoanGames.Domain.Mediator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoanGames.Application.Services
{
    public class LoanAppService : ILoanAppService
    {
        private readonly IMapper _mapper;
        private readonly ILoanRepository _repository;
        private readonly IMediatorHandler _mediator;


        public LoanAppService(IMapper mapper,
                                ILoanRepository repository,
                                IMediatorHandler mediator
            )
        {
            _mapper = mapper;
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<IEnumerable<LoanViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<LoanViewModel>>(await _repository.GetAll());
        }

        public async Task<ValidationResult> GiveBack(LoanInputModel model)
        {
            var command = _mapper.Map<GiveBackLoanCommand>(model);
            return await _mediator.SendCommand(command);
        }

        public async Task<ValidationResult> Register(LoanInputModel model)
        {
            var command = _mapper.Map<RegisterLoanCommand>(model);
            return await _mediator.SendCommand(command);
        }
    }
}
