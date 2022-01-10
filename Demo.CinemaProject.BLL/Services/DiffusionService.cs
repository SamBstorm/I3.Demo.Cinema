using Demo.CinemaProject.BLL.Entities;
using Demo.CinemaProject.BLL.Handlers;
using Demo.CinemaProject.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.CinemaProject.BLL.Services
{
    public class DiffusionService : IDiffusionRepository<Diffusion>
    {
        private readonly IDiffusionRepository<DAL.Entities.Diffusion> _diffusionRepository;
        private readonly IFilmRepository<DAL.Entities.Film> _filmRepository;
        private readonly ICinemaRepository<DAL.Entities.Cinema> _cinemaRepository;

        public DiffusionService(
            IDiffusionRepository<DAL.Entities.Diffusion> diffusionRepository,
            IFilmRepository<DAL.Entities.Film> filmRepository,
            ICinemaRepository<DAL.Entities.Cinema> cinemaRepository)
        {
            _diffusionRepository = diffusionRepository;
            _filmRepository = filmRepository;
            _cinemaRepository = cinemaRepository;
        }

        public void Delete(int id)
        {
            _diffusionRepository.Delete(id);
        }

        public IEnumerable<Diffusion> Get(DateTime date)
        {
            return _diffusionRepository.Get(date).Select(d => d.ToBLL());
        }

        public Diffusion Get(int id)    //Id : 36, c_id : 6 , f_id : 3, date : 20220110
        {
            Diffusion result = _diffusionRepository.Get(id).ToBLL();
            result.Cinema = _cinemaRepository.GetByDiffusionId(id).ToBLL();
            result.Film = _filmRepository.GetByDiffusionId(id).ToBLL();
            return result;    //Id = 36, date : 20220110, null, null
        }

        public IEnumerable<Diffusion> Get()
        {
            return _diffusionRepository.Get().Select(d => d.ToBLL());
        }

        public IEnumerable<Diffusion> GetByCinemaId(int cinema_id)
        {
            return _diffusionRepository.GetByCinemaId(cinema_id).Select(d => d.ToBLL());
        }

        public IEnumerable<Diffusion> GetByFilmId(int film_id)
        {
            return _diffusionRepository.GetByFilmId(film_id).Select(d => d.ToBLL());
        }

        public int Insert(Diffusion entity)
        {
            return _diffusionRepository.Insert(entity.ToDAL());
        }

        public void Update(int id, Diffusion entity)
        {
            _diffusionRepository.Update(id, entity.ToDAL());
        }
    }
}
