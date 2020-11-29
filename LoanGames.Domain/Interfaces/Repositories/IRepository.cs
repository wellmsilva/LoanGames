using System;

namespace LoanGames.Domain.Interfaces.Repositories
{
    public interface IRepository<T> : IDisposable where T : class
    {
       IUnitOfWork UnitOfWork { get; }
    }
}
