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
            return View();
        }

        public IActionResult Accreditation()
        {
            return View();
        }
    }
}
