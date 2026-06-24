using CodeFirst1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Diagnostics;

namespace CodeFirst1.Controllers
{
    public class HomeController : Controller
    {
        private readonly StudentDBContext dbContect;

        public HomeController( StudentDBContext _DbContect)
        {
            dbContect = _DbContect;
        }
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            var dbcontext = dbContect.Students.ToList();
            return View(dbcontext);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
