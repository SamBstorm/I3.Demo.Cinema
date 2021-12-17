using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.CinemaProject.Common.Repositories
{
    public interface IGetRepository<TEntity, TId>
    {
        TEntity Get(TId tid);
        IEnumerable<TEntity> Get();
    }
}
