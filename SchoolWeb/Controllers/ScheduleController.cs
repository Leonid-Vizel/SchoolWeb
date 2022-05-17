using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolWeb.Data;
using SchoolWeb.Models;
using System.Reflection;

namespace SchoolWeb.Controllers
{
    public class ScheduleController : Controller
    {
        private ApplicationDbContext db;
        private ScheduleInfo info;
        private readonly SignInManager<IdentityUser> SignInManager;

        public ScheduleController(ApplicationDbContext db, ScheduleInfo info, SignInManager<IdentityUser> SignInManager)
        {
            this.db = db;
            this.SignInManager = SignInManager;
            this.info = info;
        }

        public IActionResult Index()
        {
            return View(info);
        }

        #region Reset
        public IActionResult Reset()
        {
            if (!SignInManager.IsSignedIn(User))
            {
                return View(info);
            }
            return RedirectToAction(controllerName: "Admin", actionName: "NoPermissions");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reset(ScheduleInfo updateInfo)
        {
            if (!SignInManager.IsSignedIn(User))
            {
                return RedirectToAction(controllerName: "Admin", actionName: "NoPermissions");
            }
            #region Проверка корректности дат
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
            if (!ModelState.IsValid)
            {
                return View(updateInfo);
            }

            info.Copy(updateInfo);
            foreach (PropertyInfo propInfo in info.GetType().GetProperties())
            {
                SettingOption? option = db.Settings.FirstOrDefault(x => x.Name.Equals(propInfo.Name));
                if (option == null)
                {
                    option = new SettingOption()
                    {
                        Name = propInfo.Name,
                        Value = propInfo.GetValue(info).ToString()
                    };
                    await db.Settings.AddAsync(option);
                }
                else
                {
                    option.Value = propInfo.GetValue(info).ToString();
                    db.Settings.Update(option);
                }
            }
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }

    #endregion
}