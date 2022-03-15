using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolWeb.Data;
using SchoolWeb.Models;
using System.Text.Json;

namespace SchoolWeb.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext db;
        private ScheduleInfo info;
        private readonly SignInManager<IdentityUser> SignInManager;

        public AdminController(ApplicationDbContext db, ScheduleInfo info, SignInManager<IdentityUser> SignInManager)
        {
            this.db = db;
            this.SignInManager = SignInManager;
            this.info = info;
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
            if (SignInManager.IsSignedIn(User))
            {
                return View();
            }
            else
            {
                return RedirectToAction("NoPermissions");
            }
        }

        public IActionResult EditSchoolAdminisrator()
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

        public IActionResult DeleteSchoolAdminisrator()
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

        #endregion

        #region SchoolTeacher

        public IActionResult AddSchoolTeacher()
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

        public IActionResult EditSchoolTeacher()
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

        public IActionResult DeleteSchoolTeacher()
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

        #region Schedule
        public IActionResult ResetSchedule()
        {
            if (SignInManager.IsSignedIn(User))
            {
                return View(info);
            }
            else
            {
                return RedirectToAction("NoPermissions");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ResetSchedule(ScheduleInfo updateInfo)
        {
            if (SignInManager.IsSignedIn(User))
            {
                if (ModelState.IsValid)
                {
                    using (FileStream writeString = new FileStream("schedule.json", FileMode.OpenOrCreate))
                    {
                        info.Copy(updateInfo);
                        JsonSerializer.Serialize<ScheduleInfo>(writeString, info);
                    }
                    return RedirectToAction(controllerName: "Home", actionName: "Schedule");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return RedirectToAction("NoPermissions");
            }
        }

        #endregion
    }
}