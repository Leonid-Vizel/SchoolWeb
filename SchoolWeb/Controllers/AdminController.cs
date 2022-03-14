using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolWeb.Data;
using SchoolWeb.Models;

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

        #region ОГЭ
        public IActionResult AddOgeYear()
        {
            if (SignInManager.IsSignedIn(User))
            {
                return View();
            }
            else
            {
                return RedirectToAction("NoPermissions");
            }
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

        public IActionResult DeleteOgeYear(int id)
        {
            if (SignInManager.IsSignedIn(User))
            {
                OgeResult? foundResult = db.OgeResults.FirstOrDefault(x => x.Id == id);
                if (foundResult != null)
                {
                    return View((foundResult.Id, foundResult.Year));
                }
                else
                {
                    return RedirectToAction("ElementNotFound");
                }
            }
            else
            {
                return RedirectToAction("NoPermissions");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("DeleteOgeYear")]
        public IActionResult DeleteOgeYearPOST(int id)
        {
            if (SignInManager.IsSignedIn(User))
            {
                OgeResult? foundResult = db.OgeResults.FirstOrDefault(x => x.Id == id);
                if (foundResult != null)
                {
                    db.OgeResults.Remove(foundResult);
                    db.SaveChanges();
                    return RedirectToAction(controllerName: "Education", actionName: "Graduates");
                }
                else
                {
                    return RedirectToAction("ElementNotFound");
                }
            }
            else
            {
                return RedirectToAction("NoPermissions");
            }
        }
        #endregion

        #region ЕГЭ
        public IActionResult AddEgeYear()
        {
            if (SignInManager.IsSignedIn(User))
            {
                return View();
            }
            else
            {
                return RedirectToAction("NoPermissions");
            }
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
            if (SignInManager.IsSignedIn(User))
            {
                EgeResult? foundResult = db.EgeResults.FirstOrDefault(x => x.Id == id);
                if (foundResult != null)
                {
                    return View((foundResult.Id, foundResult.Year));
                }
                else
                {
                    return RedirectToAction("ElementNotFound");
                }
            }
            else
            {
                return RedirectToAction("NoPermissions");
            }
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
                    return RedirectToAction("ElementNotFound");
                }
            }
            else
            {
                return RedirectToAction("NoPermissions");
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

        #region Errors

        public IActionResult NoPermissions()
        {
            return View();
        }

        public IActionResult ElementNotFound()
        {
            return View();
        }

        #endregion

        public IActionResult ResetSchedule()
        {
            return View();
        }

        public IActionResult ViewLog()
        {
            return View();
        }
    }
}