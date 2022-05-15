using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolWeb.Data;
using SchoolWeb.Models;

namespace SchoolWeb.Controllers
{
    public class DocumentController : Controller
    {
        private ApplicationDbContext db;
        private SignInManager<IdentityUser> signInManager;
        private IWebHostEnvironment environment;

        public DocumentController(ApplicationDbContext db, SignInManager<IdentityUser> signInManager, IWebHostEnvironment environment)
        {
            this.db = db;
            this.signInManager = signInManager;
            this.environment = environment;
        }

        public IActionResult Index()
        {
            return View(db.Documents);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Index(int id = 0)
        {
            DocumentModel? foundModel = db.Documents.FirstOrDefault(x => x.Id == id);
            if (foundModel == null)
            {
                return NotFound();
            }
            return File($"documents\\{foundModel.DocumentName}", "application/pdf");
        }

        public async Task<IActionResult> Document(string name)
        {
            DocumentModel? foundModel = db.Documents.FirstOrDefault(x => x.Title.Equals(name));
            if (foundModel == null)
            {
                return NotFound();
            }
            return File($"documents\\{foundModel.DocumentName}", "application/pdf");
        }

        public IActionResult Add()
        {
            if (signInManager.IsSignedIn(User))
            {
                return View();
            }
            else
            {
                return RedirectToAction(controllerName: "Admin", actionName: "NoPermissions");
            }
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Add(DocumentModel model)
        {
            if (ModelState.IsValid)
            {
                if (db.Documents.Select(x=>x.Title).Any(x=>x.Equals(model.Title)))
                {
                    ModelState.AddModelError("Title", "Это название уже использовано");
                    return View(model);
                }
                if (!model.DocumentFile.ContentType.Equals("application/pdf"))
                {
                    ModelState.AddModelError("DocumentFile", "Неверный формат документа. Загрузите документ в формате pdf");
                    return View(model);
                }
                if (signInManager.IsSignedIn(User))
                {
                    string wwwRootImagePath = $"{environment.WebRootPath}\\documents\\";
                    string fileExtention = Path.GetExtension(model.DocumentFile.FileName);
                    model.DocumentName = $"{model.Title}{fileExtention}";
                    try
                    {
                        using (var imageCreateStream = new FileStream(Path.Combine(wwwRootImagePath, model.DocumentName), FileMode.Create))
                        {
                            await model.DocumentFile.CopyToAsync(imageCreateStream);
                        }
                    }
                    catch
                    {
                        ModelState.AddModelError("Title", "Некорректное название");
                        return View(model);
                    }
                    await db.Documents.AddAsync(model);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction(controllerName: "Admin", actionName: "NoPermissions");
                }
            }
            else
            {
                return View(model);
            }
        }

        public IActionResult Edit(int id = 0)
        {
            if (signInManager.IsSignedIn(User))
            {
                DocumentModel? foundModel = db.Documents.FirstOrDefault(x => x.Id == id);
                if (foundModel == null)
                {
                    return NotFound();
                }
                return View(foundModel);
            }
            else
            {
                return RedirectToAction(controllerName: "Admin", actionName: "NoPermissions");
            }
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Edit(DocumentModel model)
        {
            if (ModelState.IsValid || ModelState["Title"]?.ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Valid)
            {
                if (db.Photoes.Select(x => x.Title).Any(x => x.Equals(model.Title)))
                {
                    ModelState.AddModelError("Title", "Это название уже использовано");
                    return View(model);
                }
                if (signInManager.IsSignedIn(User))
                {
                    DocumentModel? foundModel = db.Documents.FirstOrDefault(x => x.Id == model.Id);
                    if (foundModel != null)
                    {
                        string wwwRootImagePath = $"{environment.WebRootPath}\\documents\\";
                        string oldPath = Path.Combine(wwwRootImagePath, foundModel.DocumentName);
                        string newFileName = $"{model.Title}{Path.GetExtension(foundModel.DocumentName)}";
                        string newPath = Path.Combine(wwwRootImagePath, newFileName);
                        try
                        {
                            System.IO.File.Copy(oldPath, newPath);
                            System.IO.File.Delete(oldPath);
                        }
                        catch
                        {
                            ModelState.AddModelError("Title", "Некорректное название");
                            return View(model);
                        }

                        foundModel.Title = model.Title;
                        foundModel.DocumentName = newFileName;
                        db.Documents.Update(foundModel);
                        await db.SaveChangesAsync();
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction(controllerName: "Admin", actionName: "NoPermissions");
                }
            }
            else
            {
                return View(model);
            }
        }

        public IActionResult Delete(int id = 0)
        {
            if (signInManager.IsSignedIn(User))
            {
                DocumentModel? foundModel = db.Documents.FirstOrDefault(x => x.Id == id);
                if (foundModel == null)
                {
                    return NotFound();
                }
                return View(id);
            }
            else
            {
                return RedirectToAction(controllerName: "Admin", actionName: "NoPermissions");
            }
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int id = 0)
        {
            if (signInManager.IsSignedIn(User))
            {
                DocumentModel? foundModel = db.Documents.FirstOrDefault(x => x.Id == id);
                if (foundModel != null)
                {
                    string wwwRootImagePath = $"{environment.WebRootPath}\\documents\\";
                    string oldPath = Path.Combine(wwwRootImagePath, foundModel.DocumentName);
                    try
                    {
                        System.IO.File.Delete(oldPath);
                    }
                    catch { }
                    db.Documents.Remove(foundModel);
                    await db.SaveChangesAsync();
                }
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction(controllerName: "Admin", actionName: "NoPermissions");
            }
        }
    }
}
