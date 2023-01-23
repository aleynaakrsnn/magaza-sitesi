using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TemaProje_6_;

namespace TemaProje_6_.Controllers
{
    public class SubeController : Controller
    {
        // GET: Sube
        AvmEntities db = new AvmEntities();
        public ActionResult Index()
        {
            return View(db.Sube.ToList());
        }
        public ActionResult Yenile()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Yeni(Sube save)
        {
            try
            {
                using (AvmEntities db = new AvmEntities())
                {
                    db.Sube.Add(save);
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
        public ActionResult Duzenle(int SubeNo)
        {
            using (AvmEntities db = new AvmEntities())
            {
                return View(db.Sube.Where(x => x.SubeNo == SubeNo).FirstOrDefault());
            }
        }
        [HttpPost]

        public ActionResult Duzenle(int SubeNo, Sube modify)
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
                return View(db.Sube.Where(x => x.SubeNo == id).FirstOrDefault());
            }
        }

        [HttpPost]
        public ActionResult Delete(int id, Sube sil)
        {
            try
            {
                using (AvmEntities db = new AvmEntities())
                {
                    sil = db.Sube.Where(x => x.SubeNo == id).FirstOrDefault(); db.Sube.Remove(sil);
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