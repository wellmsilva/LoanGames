using System;

namespace LoanGames.Domain.Commands.LoanCommands
{
    public class GiveBackLoanCommand : LoanCommand
    {
        public GiveBackLoanCommand(Guid gameId, Guid personId)
        {
            Person_Id = personId;
            Game_Id = gameId;
        }
    }
}
