using Demo.CinemaProject.Common.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.CinemaProject.DAL.Repositories
{
    public interface IFilmRepository<TFilm> : IRepository<TFilm, int> ,
        IGetByDiffusionRepository<TFilm>
    {
        public IEnumerable<TFilm> GetByYear(int year);
    }
}
