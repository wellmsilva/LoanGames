using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace LoanGames.Application.ViewModels
{
   public class GameViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Nome é um campo obrigatório")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Nome")]
        public string Name { get; set; }
        public virtual IEnumerable<LoanViewModel> Loans { get; set; }

        public bool Loaned => Loans.Any(x => !x.DateReturn.HasValue);
     
    }
}
