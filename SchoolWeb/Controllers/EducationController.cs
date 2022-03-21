using Microsoft.AspNetCore.Mvc;
using SchoolWeb.Data;
using SchoolWeb.Models;

namespace SchoolWeb.Controllers
{
    public class EducationController : Controller
    {
        private ApplicationDbContext db;

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
            return View(new TotalResults()
            {
                Ege = db.EgeResults.OrderBy(x => x.Year),
                Oge = db.OgeResults.OrderBy(x => x.Year)
            });
        }

        public IActionResult Additional()
        {
            return View();
        }
    }
}