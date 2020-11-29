
using System.Collections.Generic;

namespace LoanGames.Domain.Entities
{
    public class Game : Entity
    {
        protected Game() { }

        public Game(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
        public virtual IEnumerable<Loan> Loans { get; set; }
    }
}
