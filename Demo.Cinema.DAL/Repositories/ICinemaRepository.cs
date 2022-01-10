using System;
using System.Collections.Generic;
using System.Text;
using Demo.CinemaProject.Common.Repositories;
using Demo.CinemaProject.DAL.Entities;

namespace Demo.CinemaProject.DAL.Repositories
{
    public interface ICinemaRepository<TCinema> : IRepository<TCinema,int>
    {
        IEnumerable<TCinema> GetByDiffusion(int id_movie, DateTime DateDiffusion);
        IEnumerable<TCinema> GetByFilm(int id_movie);
    }
}
