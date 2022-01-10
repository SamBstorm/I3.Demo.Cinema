using Demo.CinemaProject.BLL.Entities;
using Demo.CinemaProject.BLL.Handlers;
using Demo.CinemaProject.Common.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.CinemaProject.BLL.Services
{
    public class FilmService : IRepository<Film, int>
    {
        private readonly IRepository<DAL.Entities.Film,int> _filmRepository;

        public FilmService(IRepository<DAL.Entities.Film, int> repository)
        {
            _filmRepository = repository;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Film Get(int tid)
        {
            return _filmRepository.Get(tid).ToBLL();
        }

        public IEnumerable<Film> Get()
        {
            throw new NotImplementedException();
        }

        public int Insert(Film entity)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Film entity)
        {
            throw new NotImplementedException();
        }
    }
}
