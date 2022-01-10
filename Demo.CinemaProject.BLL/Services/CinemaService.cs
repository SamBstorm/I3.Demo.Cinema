using Demo.CinemaProject.BLL.Entities;
using Demo.CinemaProject.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.CinemaProject.BLL.Services
{
    public class CinemaService : ICinemaRepository<Cinema>
    {
        private readonly ICinemaRepository<DAL.Entities.Cinema> _cinemaRepository;

        public CinemaService(ICinemaRepository<DAL.Entities.Cinema> repository)
        {
            _cinemaRepository = repository;
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Cinema Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cinema> Get()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cinema> GetByDiffusion(int id_movie, DateTime DateDiffusion)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cinema> GetByFilm(int id_movie)
        {
            throw new NotImplementedException();
        }

        public int Insert(Cinema entity)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Cinema entity)
        {
            throw new NotImplementedException();
        }
    }
}
