using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_StokTakipOtomasyonu.Models.Entity;

namespace MVC_StokTakipOtomasyonu.Controllers
{
    public class BirimlerController : Controller
    {
        MVC_StokTakipEntities db = new MVC_StokTakipEntities();
        
        public ActionResult Index()
        {
            return View(db.Birimler.ToList());
        }

        [HttpGet] // Geçiş işlemlerinin yapılacağı alan GET
        public ActionResult Ekle()
        {
            return View("Kaydet");
        }

        [HttpPost] // Ekleme işlerinin yapılacağı alan POST 
        public ActionResult Kaydet(Birimler p)
        {
            if (p.ID == 0)
            {
                db.Birimler.Add(p); //Ekleme yapılacak olan değer ID'si 0 olarak gelir ve kayıt eder
            }
            else
            {
                db.Entry(p).State = System.Data.Entity.EntityState.Modified; // ID sıfırdan farklı ise güncelleme
            }
            
            db.SaveChanges();
            return RedirectToAction("Index"); 
        }
        public ActionResult GuncelleBilgiGetir(Birimler p)
        {
            var model = db.Birimler.Find(p.ID);
            if (model == null) return HttpNotFound();
            return View("Kaydet",model);            
        }
        public ActionResult SilBilgiGetir(Birimler p)
        {
            var model = db.Birimler.Find(p.ID);
            if (model == null) return HttpNotFound();
            return View(model);
        }
        public ActionResult Sil(Birimler p)
        {
            db.Entry(p).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}