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
        public ActionResult GuncelleBilgiGetir(Kategoriler p)
        {
           var model = db.Kategoriler.Find(p.ID); //ID ye göre veri çekme
            
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
        public ActionResult Guncelle(Kategoriler p)
        {
            db.Entry(p).State = System.Data.Entity.EntityState.Modified; //Güncelleme işlemini yapan komut
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SilBilgiGetir(Kategoriler p)
        {
            var model = db.Kategoriler.Find(p.ID); // Find işlemi ID ye göre arama yapar.
            if (model == null) return HttpNotFound();        
            return View(model);
        }
        public ActionResult Sil(Kategoriler p)
        {
            db.Entry(p).State = System.Data.Entity.EntityState.Deleted; //Silme işlemini yapan komut
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}