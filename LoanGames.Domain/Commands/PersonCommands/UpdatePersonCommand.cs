using System;
using System.Collections.Generic;
using System.Text;

namespace LoanGames.Domain.Commands.PersonCommands
{
    public class UpdatePersonCommand : PersonCommand
    {      

        public UpdatePersonCommand(Guid id, string name, string phone)
        {
            Id = id;
            Name = name;
            Phone = phone;
        }
    }
}
