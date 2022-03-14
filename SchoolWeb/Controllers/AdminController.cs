using Microsoft.AspNetCore.Mvc;

namespace SchoolWeb.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult ResetSchedule()
        {
            return View();
        }

        #region ОГЭ
        public IActionResult AddOgeYear()
        {
            return View();
        }

        public IActionResult DeleteOgeYear()
        {
            return View();
        }
        #endregion

        #region ЕГЭ
        public IActionResult AddEgeYear()
        {
            return View();
        }

        public IActionResult DeleteEgeYear()
        {
            return View();
        }
        #endregion

        #region SchoolAdminisrator

        public IActionResult AddSchoolAdminisrator()
        {
            return View();
        }

        public IActionResult EditSchoolAdminisrator()
        {
            return View();
        }

        public IActionResult DeleteSchoolAdminisrator()
        {
            return View();
        }

        #endregion

        #region SchoolTeacher

        public IActionResult AddSchoolTeacher()
        {
            return View();
        }

        public IActionResult EditSchoolTeacher()
        {
            return View();
        }

        public IActionResult DeleteSchoolTeacher()
        {
            return View();
        }

        #endregion

        #region WebAdmin

        public IActionResult RegisterWebAdmin()
        {
            return View();
        }

        public IActionResult DeleteWebAdmin()
        {
            return View();
        }

        #endregion

        public IActionResult ViewLog()
        {
            return View();
        }
    }
}