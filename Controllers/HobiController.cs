using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCv.Models.Entity;
using MVCCv.Repositories;

namespace MVCCv.Controllers
{
    public class HobiController : Controller
    {
        // GET: Hobi
        GenericRepository<TblHobilerim> repo = new GenericRepository<TblHobilerim>();


        public ActionResult Index()
        {
            var hobiler = repo.List();
            return View(hobiler);
        }

        [HttpGet]
        public ActionResult Duzenle(int id)
        {
            var hobi = repo.Find(x=>x.ID == id);
            return View(hobi);
        }

        [HttpPost]
        public ActionResult Duzenle(TblHobilerim t)
        {
            var hobi = repo.Find(x=>x.ID ==t.ID);
            hobi.Aciklama1 = t.Aciklama1;
            hobi.Aciklama2 = t.Aciklama2;
            repo.TUpdate(hobi);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Ekle() 
        { 
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(TblHobilerim t)
        {
            repo.TAdd(t);
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            TblHobilerim t = repo.Find(x=>x.ID==id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
    }
}