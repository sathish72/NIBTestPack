using System;
using BusinessService.Entities;

namespace DataAccess
{
    public interface IUnitOfWork<out TContext>: IDisposable where TContext : IBaseContext
    {
        TContext Context { get; }
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        void Save();
        void Complete();
    }
}
