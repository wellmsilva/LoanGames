using System;
using System.Collections.Generic;
using System.Text;

namespace LoanGames.Domain.Commands.GameCommands
{
    public class UpdateGameCommand : GameCommand
    {
        public UpdateGameCommand(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
