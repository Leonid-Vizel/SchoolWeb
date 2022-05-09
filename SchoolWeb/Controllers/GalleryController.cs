using Microsoft.AspNetCore.Mvc;
using SchoolWeb.Data;
using SchoolWeb.Models;
using System.Drawing;
using System.Drawing.Imaging;

namespace SchoolWeb.Controllers
{
    public class GalleryController : Controller
    {
        private ApplicationDbContext db;

        public GalleryController(ApplicationDbContext db)
        {
            this.db = db;
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
            PhotoModel? model = db.Photoes.FirstOrDefault(x=>x.Id == id);
            if (model != null)
            {
                return View(model);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
