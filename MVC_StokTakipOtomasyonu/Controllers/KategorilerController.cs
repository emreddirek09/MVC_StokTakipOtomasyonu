using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_StokTakipOtomasyonu.Models.Entity; // entity model kullanmak için eklenen

namespace MVC_StokTakipOtomasyonu.Controllers
{
    public class KategorilerController : Controller
    {
        MVC_StokTakipEntities db = new MVC_StokTakipEntities();

        public ActionResult Index()
        {
            return View(db.Kategoriler.ToList()); // Listeleme komutu
        }

        public ActionResult Ekle ()
         {
            return View();
        }
        public ActionResult Ekle2(Kategoriler p) //Yeni Kategori Ekleme Komutu *Ekle.cshtml sayfası form action dan yönlendirme alıyor.
        {
            db.Kategoriler.Add(p); // Ekleme yapacağında ID 0 olarak kabul eder.
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}