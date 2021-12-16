using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Cinema.DAL.Repositories
{
    public interface IRepository<TEntity, TId>
    {
        IEnumerable<TEntity> Get();
        TEntity Get(TId id);
        TId Insert(TEntity entity);
        void Delete(TId id);
        void Update(TId id, TEntity entity);
    }
}
