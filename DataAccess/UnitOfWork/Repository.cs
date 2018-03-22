﻿
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BusinessService.Entities;

namespace DataAccess
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IBaseContext _context;
        private readonly IDbSet<T> _dbset;

        public Repository(IBaseContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            _context = context;
            _dbset = context.Set<T>();
        }

        public virtual IQueryable<T> GetAll()
        {
            return _dbset;
        }

        public virtual void Add(T entity)
        {
            _dbset.Add(entity);
        }

        public virtual void Delete(T entity)
        {
            var entry = _context.Entry(entity);
            entry.State = EntityState.Deleted;
            _dbset.Remove(entity);
        }

        public virtual void DeleteAll(IEnumerable<T> entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            foreach (var ent in entity)
            {
                var entry = _context.Entry(ent);
                entry.State = EntityState.Deleted;
                _dbset.Remove(ent);
            }
        }

        public virtual void Update(T entity)
        {
            var entry = _context.Entry(entity);
            _dbset.Attach(entity);
            entry.State = EntityState.Modified;
        }

        public void UpdateWithDetached(T entity)
        {
            var attached = _dbset.Attach(entity);
            var entry = _context.Entry(attached);
            entry.State = EntityState.Modified; 
        }

        public virtual bool Any()
        {
            return _dbset.Any();
        }
    }
}
