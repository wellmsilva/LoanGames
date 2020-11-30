    using FluentValidation.Results;
using LoanGames.Domain.Entities;
using LoanGames.Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LoanGames.Domain.Commands.GameCommands
{
    public class GameCommandHandler : CommandHandler,
         IRequestHandler<NewGameCommand, ValidationResult>,
         IRequestHandler<UpdateGameCommand, ValidationResult>,
         IRequestHandler<RemoveGameCommand, ValidationResult>
    {

        private readonly IGameRepository _repository;

        public GameCommandHandler(IGameRepository repository)
        {
            _repository = repository;
        }

        public async Task<ValidationResult> Handle(UpdateGameCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;

            var person = new Game(request.Id, request.Name);
            var existing = await _repository.GetByName(person.Name);

            if (existing != null && existing.Id != person.Id)
            {
                if (!existing.Equals(person))
                {
                    AddError("Esse jogo não existe");
                    return ValidationResult;
                }
            }

            _repository.Update(person);
            return await Commit(_repository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(NewGameCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;

            var person = new Game(Guid.NewGuid(), request.Name);

            if (await _repository.GetByName(person.Name) != null)
            {
                AddError("Já exitem um jogo com esse nome");
                return ValidationResult;
            }

            _repository.Add(person);
            return await Commit(_repository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RemoveGameCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;

            var person = await _repository.GetById(request.Id);

            if (person is null)
            {
                AddError("Esse jogo não existe");
                return ValidationResult;
            }

            _repository.Remove(person);
            return await Commit(_repository.UnitOfWork);
        }
    }
}
