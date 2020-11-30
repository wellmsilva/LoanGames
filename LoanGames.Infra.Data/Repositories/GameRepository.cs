using LoanGames.Domain.Entities;
using LoanGames.Domain.Interfaces.Repositories;
using LoanGames.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoanGames.Infra.Data.Repositories
{
    public class GameRepository : RepositoryBase<Game>, IGameRepository
    {
        public GameRepository(MainContext context) : base(context) { }

        public async Task<IEnumerable<Game>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<Game> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<Game> GetByName(string name)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Name == name);
        }
    }
}
