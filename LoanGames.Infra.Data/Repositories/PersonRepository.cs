using LoanGames.Domain.Entities;
using LoanGames.Domain.Interfaces.Repositories;
using LoanGames.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanGames.Infra.Data.Repositories
{
    public class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {


        public PersonRepository(MainContext context) : base(context) { }



        public async Task<IEnumerable<Person>> GetAll()
        {
            return await DbSet
                .Include(x => x.Loans)
               .ThenInclude(x => x.Game)
               .ToListAsync();
        }

        public async Task<Person> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<Person> GetByName(string name)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Name == name);
        }



    }
}
