using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LoanGames.Application.ViewModels
{
    public class PersonViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Nome é um campo obrigatório")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Nome")]
        public string Name { get;  set; }

        
        [MaxLength(11)]
        [DisplayName("Telefone")]
        public string Phone { get;  set; }

        public virtual IEnumerable<LoanViewModel> Loans { get; set; }

    }
}
