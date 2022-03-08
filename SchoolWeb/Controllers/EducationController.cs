using Microsoft.AspNetCore.Mvc;
using SchoolWeb.Data;
using SchoolWeb.Models;

namespace SchoolWeb.Controllers
{
    public class EducationController : Controller
    {
        ApplicationDbContext db;

        public EducationController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult WeekendSchool()
        {
            return View();
        }

        public IActionResult PreSchool()
        {
            return View();
        }

        public IActionResult JuniorSchool()
        {
            return View();
        }

        public IActionResult MiddleSchool()
        {
            return View();
        }

        public IActionResult HighSchool()
        {
            return View();
        }

        public IActionResult Graduates()
        {
            TotalResults results = new TotalResults()
            {
                Ege = db.egeResults,
                Oge = db.ogeResults
            };
            return View(results);
        }

        public IActionResult Additional()
        {
            return View();
        }
    }
}