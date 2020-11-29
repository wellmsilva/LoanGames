using LoanGames.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoanGames.Domain.Interfaces.Repositories
{
    public interface IPersonRepository : IRepository<Person>
    {
        Task<IEnumerable<Person>> GetAll();
        Task<Person> GetById(Guid id);
        Task<Person> GetByName(string name);
        void Add(Person entity);
        void Update(Person entity);
        void Remove(Person entity);
    }
}
