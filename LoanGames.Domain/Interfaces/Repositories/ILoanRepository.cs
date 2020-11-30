using LoanGames.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoanGames.Domain.Interfaces.Repositories
{
    public interface ILoanRepository : IRepositoryBase<Loan>
    {
        Task<Loan> GetById(Guid id);
        bool Loaned(Guid game_Id);
        Task<Loan> Get(Guid person_Id, Guid game_Id);
        Task<IEnumerable<Loan>> GetAll();
    }
}
