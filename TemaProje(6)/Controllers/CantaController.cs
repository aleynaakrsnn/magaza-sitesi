using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TemaProje_6_;

namespace TemaProje_6_.Controllers
{
    public class CantaController : Controller
    {
        // GET: Canta
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
        public ActionResult Yeni(Canta save)
        {
            try
            {
                using (AvmEntities db = new AvmEntities())
                {
                    db.Canta.Add(save);
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
        public ActionResult Duzenle(int CantaNo)
        {
            using (AvmEntities db = new AvmEntities())
            {
                return View(db.Canta.Where(x => x.CantaNo == CantaNo).FirstOrDefault());
            }
        }
        [HttpPost]

        public ActionResult Duzenle(int CantaNo, Canta modify)
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
                return View(db.Canta.Where(x => x.CantaNo == id).FirstOrDefault());
            }
        }

        [HttpPost]
        public ActionResult Delete(int id, Canta sil)
        {
            try
            {
                using (AvmEntities db = new AvmEntities())
                {
                    sil = db.Canta.Where(x => x.CantaNo == id).FirstOrDefault(); db.Canta.Remove(sil);
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