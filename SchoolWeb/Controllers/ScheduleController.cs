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
                return RedirectToAction(controllerName: "Admin", actionName: "NoPermissions");
            }
            return View(info);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reset(ScheduleInfo updateInfo)
        {
            if (!SignInManager.IsSignedIn(User))
            {
                return RedirectToAction(controllerName: "Admin", actionName: "NoPermissions");
            }
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