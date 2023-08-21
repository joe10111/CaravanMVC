using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using CaravanMVC.Models;
using CaravanMVC.DataAccess;

namespace CaravanMVC.Controllers
{
    public class WagonController : Controller
    {
        private readonly CaravanMvcContext _context;

        public WagonController(CaravanMvcContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var wagons = _context.Wagons;
            return View(wagons);
        }

        [HttpGet]
        [Route("Wagon/{id:int}")]
        public IActionResult Show(int id)
        {
            var wagons = _context.Wagons.Where(w => w.Id == id).Include(w => w.Passengers).First();
            return View(wagons);
        }
    }
}
