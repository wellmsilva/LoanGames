using LoanGames.Domain.Commands.PersonCommands.Validations;

namespace LoanGames.Domain.Commands.PersonCommands
{
    public class NewPersonCommand : PersonCommand
    {
        public NewPersonCommand(string name, string phone)
        {
            Name = name;
            Phone = phone;
        }

        public override bool IsValid()
        {
            ValidationResult = new NewPersonCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
