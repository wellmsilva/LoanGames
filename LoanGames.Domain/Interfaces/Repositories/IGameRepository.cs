using LoanGames.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoanGames.Domain.Interfaces.Repositories
{
    public interface IGameRepository : IRepositoryBase<Game>
    {
        Task<IEnumerable<Game>> GetAll();
        Task<Game> GetById(Guid id);
        Task<Game> GetByName(string name);
    }
}
