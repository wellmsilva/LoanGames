using FluentValidation;
using System;

namespace LoanGames.Domain.Commands.PersonCommands.Validations
{
    public class PersonValidation<T> : AbstractValidator<T> where T : PersonCommand
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
        protected void ValidateTelefone()
        {
            RuleFor(c => c.Phone)
                //.NotEmpty().WithMessage("Telefone é um campo obrigatório")
                .Length(0, 11).WithMessage("Telefone deve conter 11 caracteres");
        }
    }
}
