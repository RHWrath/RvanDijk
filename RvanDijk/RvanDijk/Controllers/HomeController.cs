using Microsoft.AspNetCore.Mvc;
using RvanDijk.Models;
using System.Diagnostics;

namespace RvanDijk.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Reservering()
        {
            return View();
        }
        public IActionResult Abbonement()
        {
            return View();
        }
        public IActionResult Events()
        {
            return View();
        }

        public IActionResult Instructeurs()
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
