using Demo.CinemaProject.API.Handlers;
using Demo.CinemaProject.API.Models;
using Demo.CinemaProject.Common.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Demo.CinemaProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly IFilmRepository<BLL.Entities.Film> _service;

        public FilmController(IFilmRepository<BLL.Entities.Film> service)
        {
            _service = service;
        }

        // GET: api/<FilmController>
        [HttpGet]
        public IEnumerable<Film> Get()
        {
            return _service.Get().Select(f => f.ToAPI());
        }

        // GET api/<FilmController>/5
        [HttpGet("{id}")]
        public Film Get(int id)
        {
            return _service.Get(id).ToAPI();
        }

        // POST api/<FilmController>
        [HttpPost]
        public void Post([FromBody] FilmPost value)
        {
            _service.Insert(value.ToBLL());
        }

        // PUT api/<FilmController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] FilmPost value)
        {
            _service.Update(id, value.ToBLL());
        }

        // DELETE api/<FilmController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
