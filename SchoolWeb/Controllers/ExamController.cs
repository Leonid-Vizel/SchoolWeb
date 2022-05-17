using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolWeb.Data;
using SchoolWeb.Models;

namespace SchoolWeb.Controllers
{
    public class ExamController : Controller
    {
        private ApplicationDbContext db;
        private ScheduleInfo info;
        private readonly SignInManager<IdentityUser> SignInManager;

        public ExamController(ApplicationDbContext db, ScheduleInfo info, SignInManager<IdentityUser> SignInManager)
        {
            this.db = db;
            this.SignInManager = SignInManager;
            this.info = info;
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
                return RedirectToAction(actionName: "Index");
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
                    return NotFound();
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
                    return RedirectToAction(actionName: "Index");
                }
                else
                {
                    return NotFound();
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
                return RedirectToAction(actionName: "Index");
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
                    return NotFound();
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
                    return RedirectToAction(actionName: "Index");
                }
                else
                {
                    return NotFound();
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
