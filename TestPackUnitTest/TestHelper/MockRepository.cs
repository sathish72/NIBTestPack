
using System.Collections.Generic;
using System.Linq;
using BusinessService.Entities;
using DataAccess;

namespace TestPackUnitTest
{
    public class MockRepository<T>: IRepository<T> where T : class
    {
        public List<T> Data { get; set; }

        public MockRepository(List<T> ctx)
        {
            Data = ctx;
        }

        public virtual IQueryable<T> GetAll()
        {
            return Data.AsQueryable();
        }

        public virtual void Add(T entity)
        {
            Data.Add(entity);
        }

        public virtual void Delete(T entity)
        {
            var entityToDelete = GetEntityByKey(entity);
            Data.Remove(entityToDelete);
        }

        private T GetEntityByKey(T entity)
        {
            var baseModel = (IBaseModel)entity;
            if (baseModel != null)
            {
                return Data.SingleOrDefault(x => ((IBaseModel)x).Id.Equals(baseModel.Id));
            }
            return null;
        }

        public virtual void DeleteAll(IEnumerable<T> entity)
        {
            Data.RemoveAll(entity.Contains);
        }

        public virtual void Update(T entity)
        {
            var entry = Data.SingleOrDefault(s => s == entity);
            Data.Remove(entry);
            Data.Add(entity);
        }

        public void UpdateWithDetached(T entity)
        {
            Data.Remove(GetEntityByKey(entity));
            Data.Add(entity);
        }

        public virtual bool Any()
        {
            return Data.Any();
        }
    }
}