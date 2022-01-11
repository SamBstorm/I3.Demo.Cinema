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
    public class FilmService : IFilmRepository<Film>
    {
        private readonly IFilmRepository<DAL.Entities.Film> _filmRepository;

        public FilmService(IFilmRepository<DAL.Entities.Film> repository)
        {
            _filmRepository = repository;
        }

        public void Delete(int id)
        {
            _filmRepository.Delete(id);
        }

        public Film Get(int id)
        {
            return _filmRepository.Get(id).ToBLL();
        }

        public IEnumerable<Film> Get()
        {
           return _filmRepository.Get().Select(f => f.ToBLL());
        }

        public Film GetByDiffusionId(int diffusionId)
        {
            return _filmRepository.GetByDiffusionId(diffusionId).ToBLL();
        }

        public IEnumerable<Film> GetByYear(int year)
        {
            return _filmRepository.GetByYear(year).Select(f=> f.ToBLL());
        }

        public int Insert(Film entity)
        {
            return _filmRepository.Insert(entity.ToDAL());
        }

        public void Update(int id, Film entity)
        {
            _filmRepository.Update(id, entity.ToDAL());
        }
    }
}
