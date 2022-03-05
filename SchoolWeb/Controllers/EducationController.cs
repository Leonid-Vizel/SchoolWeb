using Microsoft.AspNetCore.Mvc;
using SchoolWeb.Models;

namespace SchoolWeb.Controllers
{
    public class EducationController : Controller
    {
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
            var temp = new List<EgeResult>();
            temp.Add(new EgeResult()
            {
                Year = 2012,
                Russian = 82.04F,
                MathBase = 0F,
                MathProfi = 59F,
                History = 53.5F,
                SocialStudies = 64F,
                Physics = 69.4F,
                Chemistry = 71F,
                Geography = 0F,
                Biology = 83.5F,
                Informatics = 97F,
                English = 0F,
                Literature = 0F,
            });
            temp.Add(new EgeResult()
            {
                Year = 2013,
                Russian = 82.04F,
                MathBase = 0F,
                MathProfi = 59F,
                History = 53.5F,
                SocialStudies = 64F,
                Physics = 69.4F,
                Chemistry = 71F,
                Geography = 0F,
                Biology = 83.5F,
                Informatics = 97F,
                English = 0F,
                Literature = 0F,
            });
            temp.Add(new EgeResult()
            {
                Year = 2014,
                Russian = 82.04F,
                MathBase = 0F,
                MathProfi = 59F,
                History = 53.5F,
                SocialStudies = 64F,
                Physics = 69.4F,
                Chemistry = 71F,
                Geography = 0F,
                Biology = 83.5F,
                Informatics = 97F,
                English = 0F,
                Literature = 0F,
            });
            temp.Add(new EgeResult()
            {
                Year = 2015,
                Russian = 82.04F,
                MathBase = 0F,
                MathProfi = 59F,
                History = 53.5F,
                SocialStudies = 64F,
                Physics = 69.4F,
                Chemistry = 71F,
                Geography = 0F,
                Biology = 83.5F,
                Informatics = 97F,
                English = 0F,
                Literature = 0F,
            });

            var tempOge = new List<OgeResult>();
            tempOge.Add(new OgeResult()
            {
                Year = 2012,
                Russian = 82.04F,
                Math = 0F,
                History = 53.5F,
                SocialStudies = 64F,
                Physics = 69.4F,
                Chemistry = 71F,
                Geography = 0F,
                Biology = 83.5F,
                Informatics = 97F,
                English = 0F
            });
            tempOge.Add(new OgeResult()
            {
                Year = 2012,
                Russian = 82.04F,
                Math = 0F,
                History = 53.5F,
                SocialStudies = 64F,
                Physics = 69.4F,
                Chemistry = 71F,
                Geography = 0F,
                Biology = 83.5F,
                Informatics = 97F,
                English = 0F
            });
            tempOge.Add(new OgeResult()
            {
                Year = 2012,
                Russian = 82.04F,
                Math = 0F,
                History = 53.5F,
                SocialStudies = 64F,
                Physics = 69.4F,
                Chemistry = 71F,
                Geography = 0F,
                Biology = 83.5F,
                Informatics = 97F,
                English = 0F
            });
            tempOge.Add(new OgeResult()
            {
                Year = 2012,
                Russian = 82.04F,
                Math = 0F,
                History = 53.5F,
                SocialStudies = 64F,
                Physics = 69.4F,
                Chemistry = 71F,
                Geography = 0F,
                Biology = 83.5F,
                Informatics = 97F,
                English = 0F
            });
            tempOge.Add(new OgeResult()
            {
                Year = 2012,
                Russian = 82.04F,
                Math = 0F,
                History = 53.5F,
                SocialStudies = 64F,
                Physics = 69.4F,
                Chemistry = 71F,
                Geography = 0F,
                Biology = 83.5F,
                Informatics = 97F,
                English = 0F
            });
            TotalResults results = new TotalResults()
            {
                Ege = temp,
                Oge = tempOge
            };
            return View(results);
        }

        public IActionResult Additional()
        {
            return View();
        }
    }
}