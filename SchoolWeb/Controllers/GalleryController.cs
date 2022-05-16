using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SchoolWeb.Data;
using SchoolWeb.Models;

namespace SchoolWeb.Controllers
{
    public class GalleryController : Controller
    {
        private ApplicationDbContext db;
        private SignInManager<IdentityUser> signInManager;
        private IWebHostEnvironment environment;

        public GalleryController(ApplicationDbContext db, SignInManager<IdentityUser> signInManager, IWebHostEnvironment environment)
        {
            this.db = db;
            this.signInManager = signInManager;
            this.environment = environment;
        }

        public IActionResult Index(int id = 0) // page (Id для красоты)
        {
            int allCount = db.Photoes.Count();
            if (allCount == 0)
            {
                return View(null);
            }
            if (id * 30 >= allCount)
            {
                id = allCount / 30;
                return RedirectToAction("Index", new { id = id });
            }
            ViewData["total"] = allCount / 30;
            return View(db.Photoes.Skip(id * 30).Take(30));
        }

        public IActionResult Photo(int id = 0)
        {
            PhotoModel? model = db.Photoes.FirstOrDefault(x => x.Id == id);
            if (model != null)
            {
                return View(model);
            }
            else
            {
                return NotFound();
            }
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(PhotoModel model)
        {
            if (ModelState.IsValid)
            {
                if (db.Photoes.Select(x => x.Title).Any(x => x.Equals(model.Title)))
                {
                    ModelState.AddModelError("Title", "Это название уже использовано");
                    return View(model);
                }
                if (!model.ImageFile.FileName.EndsWith(".png") && !model.ImageFile.FileName.EndsWith(".jpg") && !model.ImageFile.FileName.EndsWith(".jpeg") && !model.ImageFile.FileName.EndsWith(".jfif"))
                {
                    ModelState.AddModelError("ImageFile", "Неверный формат. Загрузите изображение в одом из этих форматов: *.png, *.jpg, *.jpeg, *.jfif");
                    return View(model);
                }
                if (signInManager.IsSignedIn(User))
                {
                    string wwwRootImagePath = $"{environment.WebRootPath}\\gallery\\";
                    string fileExtention = Path.GetExtension(model.ImageFile.FileName);
                    model.ImageName = $"{model.Title}{fileExtention}";
                    try
                    {
                        using (var imageCreateStream = new FileStream(Path.Combine(wwwRootImagePath, model.ImageName), FileMode.Create))
                        {
                            await model.ImageFile.CopyToAsync(imageCreateStream);
                        }
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("Title", $"Некорректное название: {ex}");
                        return View(model);
                    }
                    await db.Photoes.AddAsync(model);
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

        public IActionResult Delete(int id = 0)
        {
            if (signInManager.IsSignedIn(User))
            {
                PhotoModel? foundModel = db.Photoes.FirstOrDefault(x => x.Id == id);
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
                PhotoModel? foundModel = db.Photoes.FirstOrDefault(x => x.Id == id);
                if (foundModel != null)
                {
                    string wwwRootImagePath = $"{environment.WebRootPath}\\gallery\\";
                    string oldPath = Path.Combine(wwwRootImagePath, foundModel.ImageName);
                    try
                    {
                        System.IO.File.Delete(oldPath);
                    }
                    catch { }
                    db.Photoes.Remove(foundModel);
                    await db.SaveChangesAsync();
                }
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction(controllerName: "Admin", actionName: "NoPermissions");
            }
        }

        public IActionResult Edit(int id = 0)
        {
            if (signInManager.IsSignedIn(User))
            {
                PhotoModel? foundModel = db.Photoes.FirstOrDefault(x => x.Id == id);
                if (foundModel == null)
                {
                    return NotFound();
                }
                return View(EditPhotoModel.FromPhotoModel(foundModel));
            }
            else
            {
                return RedirectToAction(controllerName: "Admin", actionName: "NoPermissions");
            }
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Edit(EditPhotoModel model)
        {
            #region Если неверная модель
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            #endregion
            #region Если не вошёл в акк
            if (!signInManager.IsSignedIn(User))
            {
                return RedirectToAction(controllerName: "Admin", actionName: "NoPermissions");
            }
            #endregion
            PhotoModel? foundModel = db.Photoes.FirstOrDefault(x => x.Id == model.Id);
            #region Если не нашлось фото в базе
            if (foundModel == null)
            {
                return NotFound();
            }
            #endregion
            #region Если неверный формат фото
            if (model.ImageFile != null && !model.ImageFile.FileName.EndsWith(".png") && !model.ImageFile.FileName.EndsWith(".jpg") && !model.ImageFile.FileName.EndsWith(".jpeg") && !model.ImageFile.FileName.EndsWith(".jfif"))
            {
                ModelState.AddModelError("ImageFile", "Неверный формат. Загрузите изображение в одом из этих форматов: *.png, *.jpg, *.jpeg, *.jfif");
                return View(model);
            }
            #endregion
            #region Если такое название уже существует
            if (!foundModel.Title.Equals(model.Title) && db.Photoes.Select(x => x.Title).Any(x => x.Equals(model.Title)))
            {
                ModelState.AddModelError("Title", "Это название уже использовано");
                return View(model);
            }
            #endregion
            string wwwRootImagePath = $"{environment.WebRootPath}\\gallery\\";
            string oldPath = Path.Combine(wwwRootImagePath, foundModel.ImageName);
            #region Если название не меняли
            if (foundModel.Title.Equals(model.Title))
            {
                if (model.ImageFile != null)
                {
                    try
                    {
                        System.IO.File.Delete(oldPath);
                        using (var imageCreateStream = new FileStream(oldPath, FileMode.Create))
                        {
                            await model.ImageFile.CopyToAsync(imageCreateStream);
                        }
                    }
                    catch
                    { }
                }
                foundModel.Description = model.Description;
                db.Photoes.Update(foundModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            #endregion
            //Title not equals
            string newFileName = $"{model.Title}{Path.GetExtension(foundModel.ImageName)}";
            foundModel.ImageName = newFileName;
            string newPath = Path.Combine(wwwRootImagePath, newFileName);
            #region Если название поменяли и загрузили фото
            if (model.ImageFile != null)
            {
                try
                {
                    System.IO.File.Delete(oldPath);
                    using (var imageCreateStream = new FileStream(newPath, FileMode.Create))
                    {
                        await model.ImageFile.CopyToAsync(imageCreateStream);
                    }
                }
                catch
                {
                    ModelState.AddModelError("Title", "Некорректное название");
                    return View(model);
                }
                foundModel.Title = model.Title;
                foundModel.Description = model.Description;
                db.Photoes.Update(foundModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            #endregion
            #region Если название поменяли, но фото не загрузили
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
            foundModel.Description = model.Description;
            db.Photoes.Update(foundModel);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
            #endregion
        }
    }
}
