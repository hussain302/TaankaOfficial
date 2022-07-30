using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Taanka.Models.WebModels;
using Taanka.WebUI.Models;

namespace Taanka.WebUI.Controllers
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
            ViewBag.Name = HttpContext.Session.GetString("Name");
            ViewBag.Role = HttpContext.Session.GetString("Role");
            
            if (ViewBag.Name != null && ViewBag.Role != null)
            {
                

                return View();
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
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