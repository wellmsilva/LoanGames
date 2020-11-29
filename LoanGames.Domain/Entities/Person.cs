using System;
using System.Collections.Generic;

namespace LoanGames.Domain.Entities
{
    public class Person : Entity
    {
        protected Person() { }

        public Person(Guid id, string name, string phone)
        {
            Id = id;
            Name = name;
            Phone = phone;
        }

        public string Name { get; private set; }
        public string Phone { get; private set; }

        public virtual IEnumerable<Loan> Loans { get; set; }
    
    }
}
