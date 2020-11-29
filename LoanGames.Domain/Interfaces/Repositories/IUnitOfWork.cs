using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoanGames.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
