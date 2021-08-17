﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_StokTakipOtomasyonu.Models.Entity;

namespace MVC_StokTakipOtomasyonu.Controllers
{
    public class UrunlerController : Controller
    {
        MVC_StokTakipEntities db = new MVC_StokTakipEntities();
        public ActionResult Index()
        {
            var model = db.Urunler.ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            var model = new Urunler();
            NewMethod(model);
            return View(model);
        }

        private void NewMethod(Urunler model)
        {
            List<Kategoriler> kategorilers = db.Kategoriler.OrderBy(x => x.Kategori).ToList();
            model.KategoriListesi = (from x in kategorilers
                                     select new SelectListItem
                                     {
                                         Text = x.Kategori,
                                         Value = x.ID.ToString()
                                     }).ToList();
            List<Birimler> birimlers = db.Birimler.OrderBy(x => x.Birim).ToList();
            model.BirimListesi = (from x in birimlers
                                  select new SelectListItem
                                  {
                                      Text = x.Birim,
                                      Value = x.ID.ToString()
                                  }).ToList();
            
        }

        [HttpPost]
        public ActionResult Ekle(Urunler u)
        {
            if (!ModelState.IsValid)
            {
                var model = new Urunler();
                NewMethod(model);
                return View(model);
            }
            db.Entry(u).State = System.Data.Entity.EntityState.Added;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult GetMarka(int id2)
        {
            //Seçilen Kategoriye göre marka bilgisi çağırma

            var model = new Urunler();


            List<Markalar> markaListe = db.Markalar.Where(x => x.KategoriID == id2).OrderBy(x => x.Marka).ToList();
            model.MarkaListesi = (from x in markaListe
                                  select new SelectListItem
                                  {
                                      Text = x.Marka,
                                      Value = x.ID.ToString()
                                  }).ToList();
            model.MarkaListesi.Insert(0, new SelectListItem { Text= "Seçiniz", Value = "" });
            return Json(model.MarkaListesi, JsonRequestBehavior.AllowGet); // json türünde veri döndürcek
        }

    }
}