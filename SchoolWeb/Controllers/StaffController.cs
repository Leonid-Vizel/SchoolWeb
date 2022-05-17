using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolWeb.Data;
using SchoolWeb.Models;

namespace SchoolWeb.Controllers
{
    public class StaffController : Controller
    {
        private ApplicationDbContext db;
        private readonly SignInManager<IdentityUser> SignInManager;

        public StaffController(ApplicationDbContext db, SignInManager<IdentityUser> SignInManager)
        {
            this.db = db;
            this.SignInManager = SignInManager;
        }

        public IActionResult Index()
        {
            return View(new TotalStaff()
            {
                Staff = db.SchoolStaff,
                Administration = db.SchoolAdministration
            });
        }

        #region Adminisrator

        #region Add
        public IActionResult AddAdminisrator()
        {
            if (!SignInManager.IsSignedIn(User))
            {
                return RedirectToAction(controllerName: "Admin", actionName: "NoPermissions");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAdminisrator(Administration administration)
        {
            if (!SignInManager.IsSignedIn(User))
            {
                return RedirectToAction(controllerName: "Admin", actionName: "NoPermissions");
            }
            if (!ModelState.IsValid)
            {
                return View(administration);
            }
            await db.SchoolAdministration.AddAsync(administration);
            await db.SaveChangesAsync();
            return RedirectToAction("Staff");
        }
        #endregion

        #region Edit
        public IActionResult EditAdminisrator(int id)
        {
            if (!SignInManager.IsSignedIn(User))
            {
                return RedirectToAction(controllerName: "Admin", actionName: "NoPermissions");
            }
            Administration? foundAdmin = db.SchoolAdministration.FirstOrDefault(x => x.Id == id);
            if (foundAdmin == null)
            {
                return NotFound();
            }
            return View(foundAdmin);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAdminisrator(Administration administration)
        {
            if (!SignInManager.IsSignedIn(User))
            {
                return RedirectToAction(controllerName: "Admin", actionName: "NoPermissions");
            }
            if (!ModelState.IsValid)
            {
                return View(administration);
            }
            db.SchoolAdministration.Update(administration);
            await db.SaveChangesAsync();
            return RedirectToAction("Staff");
        }
        #endregion

        #region Delete
        public IActionResult DeleteAdminisrator(int id)
        {
            if (!SignInManager.IsSignedIn(User))
            {
                return RedirectToAction(controllerName: "Admin", actionName: "NoPermissions");
            }
            Administration? foundAdmin = db.SchoolAdministration.FirstOrDefault(x => x.Id == id);
            if (foundAdmin == null)
            {
                return NotFound();
            }
            return View((object)foundAdmin.Name);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("DeleteAdminisrator")]
        public async Task<IActionResult> DeleteAdminisratorPost(int id)
        {
            if (!SignInManager.IsSignedIn(User))
            {
                return RedirectToAction(controllerName: "Admin", actionName: "NoPermissions");
            }
            Administration? foundAdmin = db.SchoolAdministration.FirstOrDefault(x => x.Id == id);
            if (foundAdmin == null)
            {
                return NotFound();
            }
            db.SchoolAdministration.Remove(foundAdmin);
            await db.SaveChangesAsync();
            return RedirectToAction("Staff");
        }
        #endregion

        #endregion

        #region Teacher

        #region Add
        public IActionResult AddTeacher()
        {
            if (!SignInManager.IsSignedIn(User))
            {
                return RedirectToAction(controllerName: "Admin", actionName: "NoPermissions");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddTeacher(Staff staff)
        {
            if (!SignInManager.IsSignedIn(User))
            {
                return RedirectToAction(controllerName: "Admin", actionName: "NoPermissions");
            }
            if (ModelState.IsValid)
            {
                return View();
            }
            await db.SchoolStaff.AddAsync(staff);
            await db.SaveChangesAsync();
            return RedirectToAction("Staff");
        }
        #endregion

        #region Edit
        public IActionResult EditTeacher(int id)
        {
            if (!SignInManager.IsSignedIn(User))
            {
                return RedirectToAction(controllerName: "Admin", actionName: "NoPermissions");
            }
            Staff? foundStaff = db.SchoolStaff.FirstOrDefault(x => x.Id == id);
            if (foundStaff == null)
            {
                return NotFound();
            }
            return View(foundStaff);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTeacher(Staff staff)
        {
            if (!SignInManager.IsSignedIn(User))
            {
                return RedirectToAction(controllerName: "Admin", actionName: "NoPermissions");
            }
            if (ModelState.IsValid)
            {
                return View(staff);
            }
            db.SchoolStaff.Update(staff);
            await db.SaveChangesAsync();
            return RedirectToAction("Staff");
        }
        #endregion

        #region Delete
        public IActionResult DeleteTeacher(int id)
        {
            if (!SignInManager.IsSignedIn(User))
            {
                return RedirectToAction(controllerName: "Admin", actionName: "NoPermissions");
            }
            Staff? foundStaff = db.SchoolStaff.FirstOrDefault(x => x.Id == id);
            if (foundStaff == null)
            {
                return NotFound();
            }
            return View((object)foundStaff.Category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("DeleteTeacher")]
        public async Task<IActionResult> DeleteTeacherPOST(int id)
        {
            if (!SignInManager.IsSignedIn(User))
            {
                return RedirectToAction(controllerName: "Admin", actionName: "NoPermissions");
            }
            Staff? foundStaff = db.SchoolStaff.FirstOrDefault(x => x.Id == id);
            if (foundStaff == null)
            {
                return NotFound();
            }
            db.SchoolStaff.Remove(foundStaff);
            await db.SaveChangesAsync();
            return RedirectToAction("Staff");
        }
        #endregion

        #endregion
    }
}
