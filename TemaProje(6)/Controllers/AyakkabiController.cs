using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TemaProje_6_;

namespace TemaProje_6_.Controllers
{
    public class AyakkabiController : Controller
    {
        // GET: Ayakkabi
        AvmEntities db = new AvmEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Yenile()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Yeni(Ayakkabi save)
        {
            try
            {
                using (AvmEntities db = new AvmEntities())
                {
                    db.Ayakkabi.Add(save);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Duzenle(int AyakkabiNo)
        {
            using (AvmEntities db = new AvmEntities())
            {
                return View(db.Ayakkabi.Where(x => x.AyakkabiNo == AyakkabiNo).FirstOrDefault());
            }
        }
        [HttpPost]

        public ActionResult Duzenle(int AyakkabiNo, Ayakkabi modify)
        {
            try
            {
                using (AvmEntities db = new AvmEntities())
                {
                    db.Entry(modify).State = System.Data.Entity.EntityState.Modified; db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();

            }
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (AvmEntities db = new AvmEntities())
            {
                return View(db.Ayakkabi.Where(x => x.AyakkabiNo == id).FirstOrDefault());
            }
        }

        [HttpPost]
        public ActionResult Delete(int id, Ayakkabi sil)
        {
            try
            {
                using (AvmEntities db = new AvmEntities())
                {
                    sil = db.Ayakkabi.Where(x => x.AyakkabiNo == id).FirstOrDefault(); db.Ayakkabi.Remove(sil);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();

            }
        }


    }
}