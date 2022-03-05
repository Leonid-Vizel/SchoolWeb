using Microsoft.AspNetCore.Mvc;

namespace SchoolWeb.Controllers
{
    public class DocumentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult License()
        {
            return Redirect("https://elenaservis.ru/lisen.html");
        }

        public IActionResult Acceditation()
        {
            return Redirect("https://elenaservis.ru/akred.html");
        }

        public IActionResult Charter()
        {
            return Redirect("https://elenaservis.ru/doca/ustavsch.pdf");
        }

        public IActionResult PropgramPre()
        {
            return Redirect("https://elenaservis.ru/doca/doshprog.pdf");
        }

        public IActionResult PropgramJunior()
        {
            return Redirect("https://elenaservis.ru/doca/nachprog.pdf");
        }

        public IActionResult PropgramGeneral()
        {
            return Redirect("https://elenaservis.ru/doca/osnprog.pdf");
        }

        public IActionResult PropgramMiddle()
        {
            return Redirect("https://elenaservis.ru/doca/oopso2020.pdf");
        }

        public IActionResult AdmissionRegulations()
        {
            return Redirect("https://elenaservis.ru/doca/polpriem.pdf");
        }

        public IActionResult FGOSRegulations()
        {
            return Redirect("https://elenaservis.ru/doca/schmonitor.pdf");
        }

        public IActionResult AttestationRegulations()
        {
            return Redirect("https://elenaservis.ru/doca/tekon.pdf");
        }

        public IActionResult AttestationReference()
        {
            return Redirect("https://elenaservis.ru/doca/spravk.pdf");
        }
    }
}
