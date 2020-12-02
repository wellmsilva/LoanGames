using System;
using System.Collections.Generic;
using System.Text;

namespace LoanGames.Application.ViewModels
{
    public class LoanViewModel
    {
        public DateTime Date { get; set; }
        public Guid Person_Id { get; set; }
        public Guid Game_Id { get; set; }
        public string Person { get; set; }
        public string Game { get; set; }
        public DateTime? DateReturn { get; set; }

        public bool Ativo
        {
            get
            {
                return !DateReturn.HasValue;
            }
        }
    }
}
