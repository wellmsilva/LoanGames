using System;
using System.Collections.Generic;
using System.Text;

namespace LoanGames.Application.ViewModels
{
    public class LoanViewModel
    {
        public DateTime Date { get; private set; }
        public Guid Person_Id { get; private set; }
        public Guid Game_Id { get; private set; }
    }
}
