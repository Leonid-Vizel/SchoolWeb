using Microsoft.AspNetCore.Mvc;
using SchoolWeb.Data;
using SchoolWeb.Models;
using System.Diagnostics;

namespace SchoolWeb.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db;
        private ScheduleInfo info;

        public HomeController(ApplicationDbContext db, ScheduleInfo info)
        {
            this.db = db;
            this.info = info;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Info()
        {
            return View();
        }

        public IActionResult Conditions()
        {
            return View();
        }

        public IActionResult Requisites()
        {
            return View();
        }

        public IActionResult HealthAndFood()
        {
            return View();
        }

        public IActionResult Regime()
        {
            return View();
        }

        public IActionResult Location()
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