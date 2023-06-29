using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DbApple.Models;
using System.Web.Mvc;

namespace DbApple.Controllers
{

    // GET: Telefon
    public class TelefonController : Controller
        {
            AppleEntities2 db = new AppleEntities2();
            // GET: Urunler
            [HttpGet] 
            public ActionResult Index()
            {
               return View(db.Telefons.ToList());
            }

            public ActionResult Yeni()
            {
                return View();
            }

            [HttpPost]
            public ActionResult Yeni(Telefon telefon)
            {
                db.Telefons.Add(telefon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            public ActionResult Edit(int id)
            {
                var guncelle = db.Telefons.Where(x => x.TelefonNo == id).FirstOrDefault();
                return View(guncelle);
            }
            [HttpPost]
            public ActionResult Edit(int id, Telefon telefon)
            {
                db.Entry(telefon).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            public ActionResult Delete(int id)
            {
                var delete = db.Telefons.Where(x => x.TelefonNo == id).FirstOrDefault();
                return View(delete);
            }
            [HttpPost]
            public ActionResult Delete(int id, Telefon telefon)
            {
                var delete = db.Telefons.Where(x => x.TelefonNo == id).FirstOrDefault();
                db.Telefons.Remove(delete);
                db.SaveChanges();
                return RedirectToAction("Index");
            }



        }
    }
