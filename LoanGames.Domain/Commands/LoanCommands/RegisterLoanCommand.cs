using System;
using System.Collections.Generic;
using System.Text;

namespace LoanGames.Domain.Commands.LoanCommands
{
    public class RegisterLoanCommand : LoanCommand
    {
        public RegisterLoanCommand(Guid gameId, Guid personId)
        {
            Person_Id = personId;
            Game_Id = gameId;
        }
    }
}
