using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolWeb.Data;
using SchoolWeb.Models;

namespace SchoolWeb.Controllers
{
    public class ExamController : Controller
    {
        private ApplicationDbContext db;
        private readonly SignInManager<IdentityUser> SignInManager;

        public ExamController(ApplicationDbContext db ,SignInManager<IdentityUser> SignInManager)
        {
            this.db = db;
            this.SignInManager = SignInManager;
        }

        public IActionResult Index()
        {
            return View(new ExamResults()
            {
                Ege = db.EgeResults.OrderBy(x => x.Year),
                Oge = db.OgeResults.OrderBy(x => x.Year)
            });
        }

        #region ОГЭ
        public IActionResult AddOge()
        {
            if (SignInManager.IsSignedIn(User))
            {
                return View();
            }
            else
            {
                return RedirectToAction(controllerName: "Admin", actionName: "NoPermissions");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOge(OgeResult result)
        {
            if (!ModelState.IsValid)
            {
                return View(result);
            }
            await db.OgeResults.AddAsync(result);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult EditOge(int Id)
        {
            if (!SignInManager.IsSignedIn(User))
            {
                return RedirectToAction(controllerName: "Admin", actionName: "NoPermissions");
            }
            OgeResult? foundResult = db.OgeResults.FirstOrDefault(x=>x.Id == Id);
            if (foundResult == null)
            {
                return NotFound();
            }
            return View(foundResult);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditOge(OgeResult result)
        {
            if (!ModelState.IsValid)
            {
                return View(result);
            }
            db.OgeResults.Update(result);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteOge(int id)
        {
            if (!SignInManager.IsSignedIn(User))
            {
                return RedirectToAction(controllerName: "Admin", actionName: "NoPermissions");
            }
            OgeResult? foundResult = db.OgeResults.FirstOrDefault(x => x.Id == id);
            if (foundResult == null)
            {
                return NotFound();
            }
            return View(foundResult.Year);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("DeleteOge")]
        public async Task<IActionResult> DeleteOgePost(int id)
        {
            if (!SignInManager.IsSignedIn(User))
            {
                return RedirectToAction(controllerName: "Admin", actionName: "NoPermissions");
            }
            OgeResult? foundResult = db.OgeResults.FirstOrDefault(x => x.Id == id);
            if (foundResult == null)
            {
                return NotFound();
            }
            db.OgeResults.Remove(foundResult);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #endregion

        #region ЕГЭ
        public IActionResult AddEge()
        {
            if (!SignInManager.IsSignedIn(User))
            {
                return RedirectToAction(controllerName: "Admin", actionName: "NoPermissions");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEge(EgeResult result)
        {
            if (!ModelState.IsValid)
            {
                return View(result);
            }
            await db.EgeResults.AddAsync(result);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult EditEge(int Id)
        {
            if (!SignInManager.IsSignedIn(User))
            {
                return RedirectToAction(controllerName: "Admin", actionName: "NoPermissions");
            }
            EgeResult? foundResult = db.EgeResults.FirstOrDefault(x=>x.Id == Id);
            if (foundResult == null)
            {
                return NotFound();
            }
            return View(foundResult);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditEge(EgeResult result)
        {
            if (!ModelState.IsValid)
            {
                return View(result);
            }
            db.EgeResults.Update(result);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteEge(int id)
        {
            if (!SignInManager.IsSignedIn(User))
            {
                return RedirectToAction(controllerName: "Admin", actionName: "NoPermissions");
            }
            EgeResult? foundResult = db.EgeResults.FirstOrDefault(x => x.Id == id);
            if (foundResult == null)
            {
                return NotFound();
            }
            return View(foundResult.Year);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("DeleteEge")]
        public async Task<IActionResult> DeleteEgePost(int id)
        {
            if (!SignInManager.IsSignedIn(User))
            {
                return RedirectToAction(controllerName: "Admin", actionName: "NoPermissions");
            }
            EgeResult? foundResult = db.EgeResults.FirstOrDefault(x => x.Id == id);
            if (foundResult == null)
            {
                return NotFound();
            }
            db.EgeResults.Remove(foundResult);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #endregion
    }
}
