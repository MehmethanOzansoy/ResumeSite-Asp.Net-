using MVCCv.Models.Entity;
using MVCCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCv.Controllers
{
    public class DeneyimController : Controller
    {
        // GET: Deneyim

        DeneyimRepository repo = new DeneyimRepository();
        public ActionResult Index()
        {
            var deneyimler = repo.List();
            return View(deneyimler);
        }

        [HttpGet]
        public ActionResult DeneyimEkle()
        {

            return View();
        }

        [HttpPost]
        public ActionResult DeneyimEkle(TblDeneyimlerim t)
        {
           repo.TAdd(t);    
           return RedirectToAction("Index");
            
        }

        public ActionResult DeneyimSil(int id)
        {
            TblDeneyimlerim t = repo.Find(x=> x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult DeneyimGuncelle(int id)
        {
            TblDeneyimlerim t = repo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult DeneyimGuncelle(TblDeneyimlerim p)
        {
            TblDeneyimlerim t = repo.Find(x => x.ID == p.ID);
            t.Baslik = p.Baslik;
            t.AltBaslik = p.AltBaslik;
            t.Tarih = p.Tarih;
            t.Aciklama = p.Aciklama;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}