using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
            //Это оставлю на стучай если что-то будет с базой не так
            //int cock = 0;
            //foreach (string path in Directory.GetFiles(""))
            //{
            //    using (Image btmp = Image.FromFile(path))
            //    {
            //        using (MemoryStream imgStream = new MemoryStream())
            //        {
            //            btmp.Save(imgStream, ImageFormat.Jpeg);
            //            PhotoModel photo = new PhotoModel()
            //            {
            //                Title = $"Фото {++cock}",
            //                Description = "Загруженное фото",
            //                Data = imgStream.ToArray()
            //            };
            //            db.Photoes.Add(photo);
            //            db.SaveChanges();
            //        }
            //    }
            //}
            //db.SaveChanges();
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
        public async Task<IActionResult> Add([Bind("Title,Description,ImageFile")]PhotoModel model)
        {
            if (ModelState.IsValid)
            {
                if (db.Photoes.Select(x => x.Title).Any(x => x.Equals(model.Title)))
                {
                    ModelState.AddModelError("Title", "Это название уже использовано");
                    return View(model);
                }
                if (signInManager.IsSignedIn(User))
                {
                    string wwwRootImagePath = $"{environment.WebRootPath}/gallery/";
                    string fileExtention = Path.GetExtension(model.ImageFile.FileName);
                    model.ImageName = $"{model.Title}{fileExtention}";
                    using (var imageCreateStream = new FileStream(Path.Combine(wwwRootImagePath, $"{model.ImageName}"), FileMode.Create))
                    {
                        await model.ImageFile.CopyToAsync(imageCreateStream);
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

        public IActionResult Delete()
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

        public IActionResult Edit()
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
    }
}
