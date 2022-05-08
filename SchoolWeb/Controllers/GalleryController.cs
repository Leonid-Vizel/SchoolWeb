﻿using Microsoft.AspNetCore.Mvc;
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
            //int cock = 0;
            //foreach (string path in Directory.GetFiles(@"C:\Users\lorda\Desktop\Фото для сайта"))
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
            int allCount = db.Photoes.Count();
            if (id * 30 >= allCount)
            {
                id = allCount / 30 * 30;
            }
            return View(db.Photoes.Skip(id * 30).Take(30));
        }
    }
}