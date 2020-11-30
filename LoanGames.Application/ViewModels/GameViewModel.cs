using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
    }
}
