using Demo.CinemaProject.Common.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.CinemaProject.DAL.Repositories
{
    public interface IDiffusionRepository<TDiffusion> : IRepository<TDiffusion,int>
    {
    }
}
