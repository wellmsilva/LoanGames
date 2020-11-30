using System;
using System.Collections.Generic;
using System.Text;

namespace LoanGames.Domain.Commands.GameCommands
{
    public class RemoveGameCommand : GameCommand
    {
        public RemoveGameCommand(Guid id)
        {
            Id = id;
        }
    }
}
