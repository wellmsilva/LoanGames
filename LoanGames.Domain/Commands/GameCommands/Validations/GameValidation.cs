using FluentValidation;
using System;

namespace LoanGames.Domain.Commands.GameCommands.Validations
{
    public class GameValidation<T> : AbstractValidator<T> where T : GameCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateNome()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Nome é um campo obrigatório")
                .Length(3, 100).WithMessage("Nome deve conter entre 3 e 100 caracteres");
        }

    }
}
