using Microsoft.AspNetCore.Mvc;

namespace Demo.CinemaProject.ASP.Controllers
{
    public class CinemaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
