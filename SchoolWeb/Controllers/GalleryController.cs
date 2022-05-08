using Microsoft.AspNetCore.Mvc;

namespace SchoolWeb.Controllers
{
    public class GalleryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
