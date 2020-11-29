using FluentValidation.Results;
using LoanGames.Domain.Interfaces.Repositories;
using System.Threading.Tasks;

namespace LoanGames.Domain.Commands
{
    public abstract class CommandHandler
    {
        protected ValidationResult ValidationResult;

        protected CommandHandler()
        {
            ValidationResult = new ValidationResult();
        }

     
        protected async Task<ValidationResult> Commit(IUnitOfWork uow, string message)
        {
            if (!await uow.Commit()) AddError(message);

            return ValidationResult;
        }

        protected async Task<ValidationResult> Commit(IUnitOfWork uow)
        {
            return await Commit(uow, "Ocorreu um erro ao salvar os dados").ConfigureAwait(false);
        }

        protected void AddError(string mensagem)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, mensagem));
        }

    }
}
