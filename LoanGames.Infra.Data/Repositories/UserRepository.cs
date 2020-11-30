using LoanGames.Domain.Entities;
using LoanGames.Domain.Interfaces.Repositories;
using LoanGames.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoanGames.Infra.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(MainContext context) : base(context)
        {
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<User> Login(string username, string password)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.UserName == username && c.Password == password);
        }
    }
}
