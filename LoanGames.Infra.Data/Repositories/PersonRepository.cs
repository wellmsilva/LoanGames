using LoanGames.Domain.Entities;
using LoanGames.Domain.Interfaces.Repositories;
using LoanGames.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoanGames.Infra.Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        protected readonly MainContext Db;

        protected readonly DbSet<Person> DbSet;


        public PersonRepository(MainContext context)
        {
            Db = context;
            DbSet = Db.Set<Person>();
        }

        public IUnitOfWork UnitOfWork => Db;

        public void Add(Person entity)
        {
            DbSet.Add(entity);
        }
                

        public async Task<IEnumerable<Person>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<Person> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<Person> GetByName(string name)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Name == name);
        }

        public void Remove(Person entity)
        {
            DbSet.Remove(entity);
        }

        public void Update(Person entity)
        {
            DbSet.Update(entity);
        }
        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
