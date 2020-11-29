using FluentValidation.Results;
using LoanGames.Domain.Entities;
using LoanGames.Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LoanGames.Domain.Commands.PersonCommands
{
    public class PersonCommandHandler : CommandHandler,
        IRequestHandler<NewPersonCommand, ValidationResult>,
        IRequestHandler<UpdatePersonCommand, ValidationResult>,
        IRequestHandler<RemovePersonCommand, ValidationResult>
    {

        private readonly IPersonRepository _repository;

        public PersonCommandHandler(IPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task<ValidationResult> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;

            var person = new Person(request.Id, request.Name, request.Phone);
            var existing = await _repository.GetByName(person.Name);

            if (existing != null && existing.Id != person.Id)
            {
                if (!existing.Equals(person))
                {
                    AddError("Essa pessoa não existe");
                    return ValidationResult;
                }
            }

            _repository.Update(person);
            return await Commit(_repository.UnitOfWork);
        }
        public async Task<ValidationResult> Handle(RemovePersonCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;

            var person = await _repository.GetById(request.Id);

            if (person is null)
            {
                AddError("Essa pessoa não existe");
                return ValidationResult;
            }

            _repository.Remove(person);
            return await Commit(_repository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(NewPersonCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;

            var person = new Person(Guid.NewGuid(), request.Name, request.Phone);

            if (await _repository.GetByName(person.Name) != null)
            {
                AddError("Já exitem uma pessoa com esse nome");
                return ValidationResult;
            }

            _repository.Add(person);
            return await Commit(_repository.UnitOfWork);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
