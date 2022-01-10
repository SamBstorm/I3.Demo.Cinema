using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.CinemaProject.DAL.Repositories
{
    public interface IGetByDiffusionRepository<TEntity>
    {
        public TEntity GetByDiffusionId(int diffusionId);
    }
}
