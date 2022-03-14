using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolWeb.Data;
using SchoolWeb.Models;
using System.Diagnostics;

namespace SchoolWeb.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext db;
        private readonly SignInManager<IdentityUser> SignInManager;
        private readonly UserManager<IdentityUser> UserManager;

        public AdminController(ApplicationDbContext db, SignInManager<IdentityUser> SignInManager, UserManager<IdentityUser> UserManager)
        {
            this.db = db;
            this.SignInManager = SignInManager;
            this.UserManager = UserManager;
        }
        public IActionResult ResetSchedule()
        {
            return View();
        }

        #region ОГЭ
        public IActionResult AddOgeYear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOgeYear(OgeResult result)
        {
            if (ModelState.IsValid)
            {
                db.OgeResults.Add(result);
                db.SaveChanges();
                return RedirectToAction(controllerName: "Education", actionName: "Graduates");
            }
            return View(result);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddEgeYear(EgeResult result)
        {
            if (ModelState.IsValid)
            {
                db.EgeResults.Add(result);
                db.SaveChanges();
                return RedirectToAction(controllerName:"Education", actionName:"Graduates");
            }
            return View(result);
        }

        public IActionResult DeleteEgeYear(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("DeleteEgeYear")]
        public IActionResult DeleteEgeYearPOST(int id)
        {
            if (SignInManager.IsSignedIn(User))
            {
                EgeResult? foundResult = db.EgeResults.FirstOrDefault(x => x.Id == id);
                if (foundResult != null)
                {
                    db.EgeResults.Remove(foundResult);
                    db.SaveChanges();
                    return RedirectToAction(controllerName: "Education", actionName: "Graduates");
                }
                else
                {
                    return RedirectToAction(controllerName: "Education", actionName: "Graduates");
                }
            }
            else
            {
                return RedirectToAction(controllerName: "Education", actionName: "Graduates");
            }
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