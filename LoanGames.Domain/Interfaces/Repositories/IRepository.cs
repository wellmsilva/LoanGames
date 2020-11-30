using NetDevPack.Data;
using NetDevPack.Domain;
using System;

namespace LoanGames.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<T> : IRepository<T> where T : IAggregateRoot
    {       
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}
