using System;
using System.Collections.Generic;
using System.Linq;
using BusinessService.Entities;
using DataAccess;


namespace TestPackUnitTest
{
    public class MockUnitOfWork : IUnitOfWork<IMbsContext>
    {
        private readonly IMbsContext _ctx;
        private readonly Dictionary<Type, object> _repositories;

        public MockUnitOfWork(IMbsContext ctx)
        {
            _ctx = ctx;
            _repositories = new Dictionary<Type, object>();
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (_repositories.Keys.Contains(typeof(TEntity)))
            {
                return _repositories[typeof(TEntity)] as IRepository<TEntity>;
            }

            var entityName = typeof(TEntity).Name;
            var prop = _ctx.GetType().GetProperty(entityName);
            MockRepository<TEntity> repository;
            if (prop != null)
            {
                var entityValue = prop.GetValue(_ctx, null);
                repository = new MockRepository<TEntity>(entityValue as List<TEntity>);
            }
            else
            {
                repository = new MockRepository<TEntity>(new List<TEntity>());
            }
            _repositories.Add(typeof(TEntity), repository);
            return repository;
        }

        public void SetRepositoryData<TEntity>(IEnumerable<TEntity> data) where TEntity : class
        {
            IRepository<TEntity> repo = GetRepository<TEntity>();

            var mockRepo = repo as MockRepository<TEntity>;
            if (mockRepo == null)
                throw new ArgumentException(typeof(TEntity).Name);
            mockRepo.Data = data.ToList();
        }

        public void Save()
        {
        }

        public void Complete()
        {   
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1063:ImplementIDisposableCorrectly")]
        public void Dispose()
        {
        }

        public IMbsContext Context => _ctx;
    }

}