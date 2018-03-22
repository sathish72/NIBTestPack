using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{ 
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        void Add(T entity);
        void Delete(T entity);
        void DeleteAll(IEnumerable<T> entity);
        void Update(T entity);
        void UpdateWithDetached(T entity);
        bool Any();
    }
}
