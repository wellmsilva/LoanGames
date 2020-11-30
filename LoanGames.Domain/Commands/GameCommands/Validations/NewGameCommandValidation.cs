using System;
using System.Collections.Generic;
using System.Text;

namespace LoanGames.Domain.Commands.GameCommands.Validations
{
    public class NewGameCommandValidation : GameValidation<NewGameCommand>
    {
        public NewGameCommandValidation()
        {
            ValidateNome();
        }
    }
}
