using Demo.CinemaProject.Common.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.CinemaProject.DAL.Repositories
{
    public interface IDiffusionRepository<TDiffusion> : IRepository<TDiffusion,int>
    {
        public IEnumerable<TDiffusion> Get(DateTime date);
        public IEnumerable<TDiffusion> GetByCinemaId(int cinema_id);
        public IEnumerable<TDiffusion> GetByFilmId(int film_id);
    }
}
