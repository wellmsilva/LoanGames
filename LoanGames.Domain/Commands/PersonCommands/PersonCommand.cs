using System;

namespace LoanGames.Domain.Commands.PersonCommands
{
    public abstract class PersonCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public string Phone { get; protected set; }        
    }
}
