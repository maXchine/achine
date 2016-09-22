using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Achine.Common.Data.Entity
{
    public class Repository<TDbContext, TEntity> : IRepository<TEntity>
        where TDbContext : DbContext, new()
        where TEntity : class, new()
    {
        private readonly TDbContext _dbContext;
        private DbSet<TEntity> _dbSet;

        protected DbSet<T> DbSet<T>() where T : class, new()
        {
            return _dbContext.Set<T>();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool _disposed;

        public Repository()
        {
            _dbContext = new TDbContext();
            _dbSet = _dbContext.Set<TEntity>();
        }

        ~Repository()
        {
            Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                _dbContext.Dispose();
                _dbSet = null;
            }
            _disposed = true;
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Add(IEnumerable<TEntity> entities)
        {
            _dbSet.AddRange(entities);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public TEntity GetEntity(params object[] keyValues)
        {
            return _dbSet.Find(keyValues);
        }

        public TEntity GetEntity(Func<TEntity, bool> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }

        public IEnumerable<TEntity> GetEntities(Func<TEntity, bool> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }

        public IEnumerable<TEntity> GetEntities<TKey>(Func<TEntity, bool> predicate, OrderBy order, Func<TEntity, TKey> keySelector)
        {
            var queryable = _dbSet.Where(predicate);
            queryable = order.IsAcsending() ? queryable.OrderByDescending(keySelector) : queryable.OrderBy(keySelector);
            return queryable.ToList();
        }

        public IQueryable<TEntity> Queryable
        {
            get { return _dbSet == null ? null : _dbSet.AsQueryable(); }
        }

        public IQueryable<TEntity> Where(Func<TEntity, bool> predicate)
        {
            return Queryable.Where(predicate).AsQueryable();
        }
    }
}
