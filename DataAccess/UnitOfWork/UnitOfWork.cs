using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Data.Entity.Validation;
using BusinessService.Entities;
using IsolationLevel = System.Transactions.IsolationLevel;

namespace DataAccess
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : IBaseContext, new()
    {
        private readonly Dictionary<Type, object> _repositories;
        private bool _disposed;
        private readonly TransactionScope _transaction;

        protected UnitOfWork()
        {
            Context = new TContext();
            _repositories = new Dictionary<Type, object>();
            _disposed = false;
        }

        protected UnitOfWork(IsolationLevel isolationLevel): this()
        {
            _transaction = new TransactionScope(TransactionScopeOption.RequiresNew, new TransactionOptions
            {
                IsolationLevel = isolationLevel
            });
        }

        public TContext Context { get; }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (_repositories.Keys.Contains(typeof(TEntity)))
                return _repositories[typeof(TEntity)] as IRepository<TEntity>;
            
            var repository = new Repository<TEntity>(Context);
            
            _repositories.Add(typeof(TEntity), repository);

            return repository;
        }

        public void Save()
        {
            try
            {
                Context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                throw;
            }
        }

        public void Complete()
        {
            _transaction?.Complete();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _transaction?.Dispose();
                    Context.Dispose();
                }

                _disposed = true;
            }
        }
    }
}