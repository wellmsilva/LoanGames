using System.ComponentModel.DataAnnotations;

namespace LoanGames.Application.InputModels
{
    public class LoginInputModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
