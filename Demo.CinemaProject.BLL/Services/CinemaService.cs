using Demo.CinemaProject.BLL.Entities;
using Demo.CinemaProject.BLL.Handlers;
using Demo.CinemaProject.Common.Repositories;
using Demo.CinemaProject.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
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
            _cinemaRepository.Delete(id);
        }

        public Cinema Get(int id)
        {
            return _cinemaRepository.Get(id).ToBLL();
        }

        public IEnumerable<Cinema> Get()
        {
            return _cinemaRepository.Get().Select(c => c.ToBLL());
        }

        public IEnumerable<Cinema> GetByDiffusion(int id_movie, DateTime DateDiffusion)
        {
            return _cinemaRepository.GetByDiffusion(id_movie, DateDiffusion).Select(c => c.ToBLL());
        }

        public Cinema GetByDiffusionId(int diffusionId)
        {
            return _cinemaRepository.GetByDiffusionId(diffusionId).ToBLL();
        }

        public IEnumerable<Cinema> GetByFilm(int id_movie)
        {
            return _cinemaRepository.GetByFilm(id_movie).Select(c => c.ToBLL());
        }

        public int Insert(Cinema entity)
        {
            return _cinemaRepository.Insert(entity.ToDAL());
        }

        public void Update(int id, Cinema entity)
        {
            _cinemaRepository.Update(id, entity.ToDAL());
        }
    }
}
