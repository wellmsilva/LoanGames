namespace LoanGames.Domain.Commands.PersonCommands.Validations
{
    public class NewPersonCommandValidation : PersonValidation<NewPersonCommand>
    {
        public NewPersonCommandValidation()
        {
            ValidateNome();
            ValidateTelefone();
        }
    }
}
