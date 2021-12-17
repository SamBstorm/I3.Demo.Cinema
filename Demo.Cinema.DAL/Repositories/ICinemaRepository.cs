using System;
using System.Collections.Generic;
using System.Text;
using Demo.CinemaProject.Common.Repositories;
using Demo.CinemaProject.DAL.Entities;

namespace Demo.CinemaProject.DAL.Repositories
{
    public interface ICinemaRepository : IRepository<Cinema,int>
    {
        IEnumerable<Cinema> GetByDiffusion(int id_movie, DateTime DateDiffusion);
        IEnumerable<Cinema> GetByFilm(int id_movie);
    }
}
