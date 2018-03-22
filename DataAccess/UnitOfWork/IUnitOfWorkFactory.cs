

using BusinessService.Entities;

namespace DataAccess
{
    public interface IUnitOfWorkFactory<out TContext> where TContext : IBaseContext
    {
        IUnitOfWork<TContext> Resolve(System.Transactions.IsolationLevel? isolationLevel = null);
    }
}