using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanGames.Application.ViewModels
{
   public class UserViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

        [JsonIgnore]
        public string Role { get; set; }
    }
}
