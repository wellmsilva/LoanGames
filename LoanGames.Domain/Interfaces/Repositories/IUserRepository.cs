using LoanGames.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoanGames.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<User> Login(string username, string password);
        Task<User> GetById(int id);
        Task<IEnumerable<User>> GetAll();

    }
}
