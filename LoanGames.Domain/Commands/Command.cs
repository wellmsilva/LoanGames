using FluentValidation.Results;
using MediatR;
using NetDevPack.Messaging;
using System;

namespace LoanGames.Domain.Commands
{
    public class Command : Message, IRequest<ValidationResult>
    {
        public DateTime Date { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            Date = DateTime.Now;
            ValidationResult = new ValidationResult();
        }

        public virtual bool IsValid()
        {
            return ValidationResult.IsValid;
        }
    }
}
