using FluentValidation.Results;
using LoanGames.Domain.Entities;
using LoanGames.Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LoanGames.Domain.Commands.LoanCommands
{
    public class LoanCommandHandler : CommandHandler,
         IRequestHandler<RegisterLoanCommand, ValidationResult>,
         IRequestHandler<GiveBackLoanCommand, ValidationResult>
    {
        private readonly ILoanRepository _repository;

        public LoanCommandHandler(ILoanRepository repository)
        {
            _repository = repository;
        }


        public async Task<ValidationResult> Handle(RegisterLoanCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;          

            if (_repository.Loaned(request.Game_Id))
            {
                AddError("Esse game já está emprestado");
                return ValidationResult;
            }


            var loan = new Loan(request.Person_Id, request.Game_Id);
            _repository.Add(loan);
            return await Commit(_repository.UnitOfWork);

        }

        public async Task<ValidationResult> Handle(GiveBackLoanCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;

     
            var loan = await _repository.Get(request.Person_Id, request.Game_Id);

            if (loan == null)
            {
                AddError("O empréstimo para essa pessoa não existe");
                return ValidationResult;
            }

            if (loan.DateReturn != null)
            {
                AddError("Esse game não está empréstado");
                return ValidationResult;
            }
            loan.Devolver();

            _repository.Update(loan);
            return await Commit(_repository.UnitOfWork);
        }
    }
}
