using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.CinemaProject.Common.Repositories
{
    public interface IGetByDiffusionRepository<TEntity>
    {
        public TEntity GetByDiffusionId(int diffusionId);
    }
}
