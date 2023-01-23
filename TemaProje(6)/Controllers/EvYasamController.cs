using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TemaProje_6_;

namespace TemaProje_6_.Controllers
{
    public class EvYasamController : Controller
    {
        // GET: EvYasam
        AvmEntities db = new AvmEntities();
        public ActionResult Index()
        {
            return View(db.EvYasam.ToList());
        }

        public ActionResult Yenile()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Yeni(EvYasam save)
        {
            try
            {
                using (AvmEntities db = new AvmEntities())
                {
                    db.EvYasam.Add(save);
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
        public ActionResult Duzenle(int UrunNo)
        {
            using (AvmEntities db = new AvmEntities())
            {
                return View(db.EvYasam.Where(x => x.UrunNo == UrunNo).FirstOrDefault());
            }
        }
        [HttpPost]

        public ActionResult Duzenle(int UrunNo, EvYasam modify)
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
                return View(db.EvYasam.Where(x => x.UrunNo == id).FirstOrDefault());
            }
        }

        [HttpPost]
        public ActionResult Delete(int id, EvYasam sil)
        {
            try
            {
                using (AvmEntities db = new AvmEntities())
                {
                    sil = db.EvYasam.Where(x => x.UrunNo == id).FirstOrDefault(); db.EvYasam.Remove(sil);
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