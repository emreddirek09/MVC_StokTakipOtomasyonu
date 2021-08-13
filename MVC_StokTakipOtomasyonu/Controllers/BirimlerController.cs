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
            return View();
        }

        [HttpPost] // Ekleme işlerinin yapılacağı alan POST 
        public ActionResult Ekle(Birimler p)
        {
            db.Birimler.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index"); 
        }
    }
}