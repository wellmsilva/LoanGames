using LoanGames.Domain.Interfaces.Repositories;
using LoanGames.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using NetDevPack.Data;
using NetDevPack.Domain;

namespace LoanGames.Infra.Data.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class, IAggregateRoot
    {
        protected readonly MainContext Db;

        protected readonly DbSet<T> DbSet;

        public IUnitOfWork UnitOfWork => Db;

        public RepositoryBase(MainContext context)
        {
            Db = context;
            DbSet = Db.Set<T>();
        }


        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public void Remove(T entity)
        {
            DbSet.Remove(entity);
        }

        public void Update(T entity)
        {
            DbSet.Update(entity);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
