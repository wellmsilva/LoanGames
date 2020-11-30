using LoanGames.Domain.Commands.GameCommands.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanGames.Domain.Commands.GameCommands
{
    public class NewGameCommand : GameCommand
    {
        public NewGameCommand(string name)
        {
            Name = name;
        }

        public override bool IsValid()
        {
            ValidationResult = new NewGameCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
