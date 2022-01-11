using Demo.CinemaProject.ASP.Handlers;
using Demo.CinemaProject.ASP.Models;
using Demo.CinemaProject.BLL.Entities;
using Demo.CinemaProject.Common.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Demo.CinemaProject.ASP.Controllers
{
    public class CinemaController : Controller
    {
        private readonly ICinemaRepository<Cinema> _cinemaService;
        private readonly IDiffusionRepository<Diffusion> _diffusionService;
        public CinemaController(ICinemaRepository<Cinema> cinemaService,
            IDiffusionRepository<Diffusion> diffusionService)
        {
            _cinemaService = cinemaService;
            _diffusionService = diffusionService;
        }

        public IActionResult Index()
        {
            IEnumerable<CinemaListItem> model = _cinemaService.Get().Select(c => c.ToListItem());
            return View(model);
        }

        public IActionResult Details(int id)
        {
            CinemaDetails model = _cinemaService.Get(id).ToDetails();
            model.Diffusions = _diffusionService.GetByCinemaId(id).Select(d => d.ToDetails());
            return View(model);
        }
    }
}
