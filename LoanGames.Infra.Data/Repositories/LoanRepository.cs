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
    public class LoanRepository : RepositoryBase<Loan>, ILoanRepository
    {

        public LoanRepository(MainContext context) : base(context)
        {

        }

        public bool Loaned(Guid game_Id)
        {
            return DbSet.Any(x => x.Game_Id == game_Id && !x.DateReturn.HasValue);
        }

        public async Task<Loan> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<Loan> Get(Guid person_Id, Guid game_Id)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Game_Id == game_Id && x.Person_Id == person_Id);
        }

        public async Task<IEnumerable<Loan>> GetAll()
        {
            return await DbSet.ToListAsync();
        }
    }
}
