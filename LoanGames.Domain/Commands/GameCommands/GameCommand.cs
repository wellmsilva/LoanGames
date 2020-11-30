using System;
using System.Collections.Generic;
using System.Text;

namespace LoanGames.Domain.Commands.GameCommands
{
    public class GameCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
    }
}
