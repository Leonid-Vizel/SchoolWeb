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

        public AdminController(ApplicationDbContext db, SignInManager<IdentityUser> SignInManager)
        {
            this.db = db;
            this.SignInManager = SignInManager;
        }

        #region Errors

        public IActionResult NoPermissions()
        {
            return View();
        }

        #endregion

        public async Task<IActionResult> RegistrationCode()
        {
            if (SignInManager.IsSignedIn(User))
            {
                SettingOption? codeOption = db.Settings.FirstOrDefault(x => x.Name.Equals("Code"));
                if (codeOption == null)
                {
                    codeOption = new SettingOption()
                    {
                        Name = "Code",
                        Value = RandomGen.GenerateRandomString()
                    };
                    await db.Settings.AddAsync(codeOption);
                    await db.SaveChangesAsync();
                }
                return View((object)codeOption.Value);
            }
            else
            {
                return RedirectToAction("NoPermissions");
            }
        }
    }
}