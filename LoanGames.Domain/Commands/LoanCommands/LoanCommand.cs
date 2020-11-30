using System;
using System.Collections.Generic;
using System.Text;

namespace LoanGames.Domain.Commands.LoanCommands
{
    public abstract class LoanCommand : Command
    {
        public Guid Id { get; protected set; }
        public Guid Person_Id { get; protected set; }
        public Guid Game_Id { get; protected set; }
    }
}
