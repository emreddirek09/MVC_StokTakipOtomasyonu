using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_StokTakipOtomasyonu.Models.Entity;

namespace MVC_StokTakipOtomasyonu.Controllers
{
    public class MarkalarController : Controller
    {
        MVC_StokTakipEntities db = new MVC_StokTakipEntities();
        public ActionResult Index()
        {
            var model = db.Markalar.ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            SelecteBilgiGetir();
            
            return View();
        }

        private void SelecteBilgiGetir()
        {
            var model = new Markalar();
            //Dropdownliste verileri çekme işlemi
            // 1.yöntem ViewBag.KategoriID = new SelectList(db.Kategoriler, "ID", "Kategori", model.KategoriID);
            //2.yöntem
            // 2.yöntem kullanılırken view tarafınfa null yerine liste çekilecek.
            List<SelectListItem> liste = new List<SelectListItem>(
                from x in db.Kategoriler
                select new SelectListItem
                {
                    Value = x.ID.ToString(),
                    Text = x.Kategori
                }
                ).ToList();
            ViewBag.l = liste;
        }

        [HttpPost]
        public ActionResult Ekle(Markalar m)
        {
            if (!ModelState.IsValid) //Hata mesajı verdirirken dropdownliste hatayı önlemek için tekrar bir veri çekme işlemi uygulandı.
            {
                ViewBag.KategoriID = new SelectList(db.Kategoriler, "ID", "Kategori", m.KategoriID);
                return View("Ekle"); 
            }
            if (m.ID == 0)
            {
                db.Markalar.Add(m);
            }
            else
            {
                db.Entry(m).State = System.Data.Entity.EntityState.Modified;                    
            }
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult GuncelleBilgiGetir(int id)
        {
            SelecteBilgiGetir();
            var a = db.Markalar.Find(id);
            return View(a);
        }
        public ActionResult Guncelle(Markalar p)
        {
            if (!ModelState.IsValid)
            {
                SelecteBilgiGetir();
                return View("GuncelleBilgiGetir");
            }
            else
            db.Entry(p).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}