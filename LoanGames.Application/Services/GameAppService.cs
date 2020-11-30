using AutoMapper;
using FluentValidation.Results;
using LoanGames.Application.Interfaces;
using LoanGames.Application.ViewModels;
using LoanGames.Domain.Commands.GameCommands;
using LoanGames.Domain.Commands.LoanCommands;
using LoanGames.Domain.Interfaces.Repositories;
using LoanGames.Domain.Mediator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoanGames.Application.Services
{
    public class GameAppService : IGameAppService
    {

        private readonly IMapper _mapper;
        private readonly IGameRepository _gameRepository;
        private readonly IMediatorHandler _mediator;


        public GameAppService(IMapper mapper,
                                IGameRepository gameRepository,
                                IMediatorHandler mediator
            )
        {
            _mapper = mapper;
            _gameRepository = gameRepository;
            _mediator = mediator;
        }



        public async Task<ValidationResult> Add(GameViewModel model)
        {
            var command = _mapper.Map<NewGameCommand>(model);
            return await _mediator.SendCommand(command);
        }

        public async Task<IEnumerable<GameViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<GameViewModel>>(await _gameRepository.GetAll());
        }

        public async Task<GameViewModel> GetById(Guid id)
        {
            return _mapper.Map<GameViewModel>(await _gameRepository.GetById(id));
        }

        public async Task<GameViewModel> GetByName(string name)
        {
            return _mapper.Map<GameViewModel>(await _gameRepository.GetByName(name));
        }

        public async Task<ValidationResult> RegistraDevolucao(Guid id, Guid personId)
        {
            var command = new GiveBackLoanCommand(id, personId);
            return await _mediator.SendCommand(command);
        }

        public async Task<ValidationResult> RegistraEmprestimo(Guid id, Guid personId)
        {

            var command = new  RegisterLoanCommand(id, personId);
            return await _mediator.SendCommand(command);
        }

        public async Task<ValidationResult> Remove(Guid id)
        {
            var command = _mapper.Map<RemoveGameCommand>(id);
            return await _mediator.SendCommand(command);
        }

        public async Task<ValidationResult> Update(GameViewModel model)
        {
            var command = _mapper.Map<UpdateGameCommand>(model);
            return await _mediator.SendCommand(command);
        }
    }
}
