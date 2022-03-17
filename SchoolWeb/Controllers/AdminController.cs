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
        public async Task<IActionResult> AddOgeYear(OgeResult result)
        {
            if (ModelState.IsValid)
            {
                await db.OgeResults.AddAsync(result);
                await db.SaveChangesAsync();
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
                    return View(foundResult.Year);
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
        public async Task<IActionResult> DeleteOgeYearPOST(int id)
        {
            if (SignInManager.IsSignedIn(User))
            {
                OgeResult? foundResult = db.OgeResults.FirstOrDefault(x => x.Id == id);
                if (foundResult != null)
                {
                    db.OgeResults.Remove(foundResult);
                    await db.SaveChangesAsync();
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
        public async Task<IActionResult> AddEgeYear(EgeResult result)
        {
            if (ModelState.IsValid)
            {
                await db.EgeResults.AddAsync(result);
                await db.SaveChangesAsync();
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
                    return View(foundResult.Year);
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
        public async Task<IActionResult> DeleteEgeYearPOST(int id)
        {
            if (SignInManager.IsSignedIn(User))
            {
                EgeResult? foundResult = db.EgeResults.FirstOrDefault(x => x.Id == id);
                if (foundResult != null)
                {
                    db.EgeResults.Remove(foundResult);
                    await db.SaveChangesAsync();
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

        #region Adminisrator

        #region Add
        public IActionResult AddAdminisrator()
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
        public async Task<IActionResult> AddAdminisrator(Administration administration)
        {
            if (SignInManager.IsSignedIn(User))
            {
                if (ModelState.IsValid)
                {
                    await db.SchoolAdministration.AddAsync(administration);
                    await db.SaveChangesAsync();
                    return RedirectToAction(controllerName: "Home", actionName: "Staff");
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

        #region Edit
        public IActionResult EditAdminisrator(int id)
        {
            if (SignInManager.IsSignedIn(User))
            {
                Administration? foundAdmin = db.SchoolAdministration.FirstOrDefault(x=>x.Id == id);
                if (foundAdmin != null)
                {
                    return View(foundAdmin);
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
        public async Task<IActionResult> EditAdminisrator(Administration administration)
        {
            if (SignInManager.IsSignedIn(User))
            {
                if (ModelState.IsValid)
                {
                    db.SchoolAdministration.Update(administration);
                    await db.SaveChangesAsync();
                    return RedirectToAction(controllerName: "Home", actionName: "Staff");
                }
                else
                {
                    return View(administration);
                }
            }
            else
            {
                return RedirectToAction("NoPermissions");
            }
        }
        #endregion

        #region Delete
        public IActionResult DeleteAdminisrator(int id)
        {
            if (SignInManager.IsSignedIn(User))
            {
                Administration? foundAdmin = db.SchoolAdministration.FirstOrDefault(x=>x.Id == id);
                if (foundAdmin != null)
                {
                    return View((object)foundAdmin.Name);
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
        [ActionName("DeleteAdminisrator")]
        public async Task<IActionResult> DeleteAdminisratorPOST(int id)
        {
            if (SignInManager.IsSignedIn(User))
            {
                Administration? foundAdmin = db.SchoolAdministration.FirstOrDefault(x => x.Id == id);
                if (foundAdmin != null)
                {
                    db.SchoolAdministration.Remove(foundAdmin);
                    await db.SaveChangesAsync();
                    return RedirectToAction(controllerName: "Home", actionName: "Staff");
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

        #endregion

        #region Teacher

        #region Add
        public IActionResult AddTeacher()
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
        public async Task<IActionResult> AddTeacher(Staff staff)
        {
            if (SignInManager.IsSignedIn(User))
            {
                if (ModelState.IsValid)
                {
                    await db.SchoolStaff.AddAsync(staff);
                    await db.SaveChangesAsync();
                    return RedirectToAction(controllerName: "Home", actionName: "Staff");
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

        #region Edit
        public IActionResult EditTeacher(int id)
        {
            if (SignInManager.IsSignedIn(User))
            {
                Staff? foundStaff = db.SchoolStaff.FirstOrDefault(x => x.Id == id);
                if (foundStaff != null)
                {
                    return View(foundStaff);
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
        public async Task<IActionResult> EditTeacher(Staff staff)
        {
            if (SignInManager.IsSignedIn(User))
            {
                if (ModelState.IsValid)
                {
                    db.SchoolStaff.Update(staff);
                    await db.SaveChangesAsync();
                    return RedirectToAction(controllerName: "Home", actionName: "Staff");
                }
                else
                {
                    return View(staff);
                }
            }
            else
            {
                return RedirectToAction("NoPermissions");
            }
        }
        #endregion

        #region Delete
        public IActionResult DeleteTeacher(int id)
        {
            if (SignInManager.IsSignedIn(User))
            {
                Staff? foundStaff = db.SchoolStaff.FirstOrDefault(x => x.Id == id);
                if (foundStaff != null)
                {
                    return View((object)foundStaff.Category);
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
        [ActionName("DeleteTeacher")]
        public async Task<IActionResult> DeleteTeacherPOST(int id)
        {
            if (SignInManager.IsSignedIn(User))
            {
                Staff? foundStaff = db.SchoolStaff.FirstOrDefault(x => x.Id == id);
                if (foundStaff != null)
                {
                    db.SchoolStaff.Remove(foundStaff);
                    await db.SaveChangesAsync();
                    return RedirectToAction(controllerName: "Home", actionName: "Staff");
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
                #region Checking Dates
                if (updateInfo.Holiday1Start.Date >= updateInfo.Holiday1End.Date)
                {
                    ModelState.AddModelError("Holiday1Start", "Начало каникул должно быть раньше конца");
                }
                if (updateInfo.Holiday2Start.Date >= updateInfo.Holiday2End.Date)
                {
                    ModelState.AddModelError("Holiday2Start", "Начало каникул должно быть раньше конца");
                }
                if (updateInfo.Holiday3Start.Date >= updateInfo.Holiday3End.Date)
                {
                    ModelState.AddModelError("Holiday3Start", "Начало каникул должно быть раньше конца");
                }
                if (updateInfo.Holiday4Start.Date >= updateInfo.Holiday4End.Date)
                {
                    ModelState.AddModelError("Holiday4Start", "Начало каникул должно быть раньше конца");
                }

                if (updateInfo.Quarter1Start.Date >= updateInfo.Quarter1End.Date)
                {
                    ModelState.AddModelError("Quarter1Start", "Начало четверти должно быть раньше конца");
                }
                if (updateInfo.Quarter2Start.Date >= updateInfo.Quarter2End.Date)
                {
                    ModelState.AddModelError("Quarter2Start", "Начало четверти должно быть раньше конца");
                }
                if (updateInfo.Quarter3Start.Date >= updateInfo.Quarter3End.Date)
                {
                    ModelState.AddModelError("Quarter3Start", "Начало четверти должно быть раньше конца");
                }
                if (updateInfo.Quarter4Start.Date >= updateInfo.Quarter4End.Date)
                {
                    ModelState.AddModelError("Quarter4Start", "Начало четверти должно быть раньше конца");
                }
                #endregion
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