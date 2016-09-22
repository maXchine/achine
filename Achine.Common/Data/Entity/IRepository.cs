using System;
using System.Collections.Generic;
using System.Linq;

namespace Achine.Common.Data.Entity
{
    public interface IRepository<TEntity> : IDisposable
        where TEntity : class, new()
    {

        void Add(TEntity entity);

        void Add(IEnumerable<TEntity> entities);

        void Save();

        TEntity GetEntity(params object[] keyValues);

        TEntity GetEntity(Func<TEntity, bool> predicate);

        IEnumerable<TEntity> GetEntities(Func<TEntity, bool> predicate);

        IEnumerable<TEntity> GetEntities<TKey>(Func<TEntity, bool> predicate, OrderBy order, Func<TEntity, TKey> keySelector);
        
        IQueryable<TEntity> Queryable { get; }

        IQueryable<TEntity> Where(Func<TEntity, bool> predicate);

    }
}
