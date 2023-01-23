using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TemaProje_6_;


namespace TemaProje_6_.Controllers
{
    public class KiyafetController : Controller
    {
        // GET: Kiyafet
        AvmEntities db = new AvmEntities();
        public ActionResult KIndex()
        {
            return View(db.Kiyafet.ToList());
        }
        public ActionResult Yenile()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Yeni(Kiyafet save)
        {
            try
            {
                using (AvmEntities db = new AvmEntities())
                {
                    db.Kiyafet.Add(save);
                    db.SaveChanges();
                }
                return RedirectToAction("KIndex");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Duzenle(int KiyafetNo)
        {
            using (AvmEntities db = new AvmEntities())
            {
                return View(db.Kiyafet.Where(x => x.KiyafetNo == KiyafetNo).FirstOrDefault());
            }
        }
        [HttpPost]

        public ActionResult Duzenle(int KiyafetNo, Kiyafet modify)
        {
            try
            {
                using (AvmEntities db = new AvmEntities())
                {
                    db.Entry(modify).State = System.Data.Entity.EntityState.Modified; db.SaveChanges();
                }
                return RedirectToAction("KIndex");
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
                return View(db.Kiyafet.Where(x => x.KiyafetNo == id).FirstOrDefault());
            }
        }

        [HttpPost]
        public ActionResult Delete(int id, Kiyafet sil)
        {
            try
            {
                using (AvmEntities db = new AvmEntities())
                {
                    sil = db.Kiyafet.Where(x => x.KiyafetNo == id).FirstOrDefault(); db.Kiyafet.Remove(sil);
                    db.SaveChanges();
                }
                return RedirectToAction("KIndex");
            }
            catch
            {
                return View();

            }
        }
    }
}