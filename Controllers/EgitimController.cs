using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using MVCCv.Models.Entity;
using MVCCv.Repositories;

namespace MVCCv.Controllers
{
    public class EgitimController : Controller
    {
        // GET: Egitim

        GenericRepository<TblEgitimlerim> repo = new GenericRepository<TblEgitimlerim>();
        public ActionResult Index()
        {
            var egitim = repo.List();
            return View(egitim);
        }

        [HttpGet]

        public ActionResult EgitimEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EgitimEkle(TblEgitimlerim t)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimEkle");
            }
            else
            {
                repo.TAdd(t);
                return RedirectToAction("Index");
            }

        }

        public ActionResult EgitimSil(int id)
        {
            TblEgitimlerim t = repo.Find(x=>x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EgitimGetir(int id)
        {
            var egitim = repo.Find(x=>x.ID==id);
            return View(egitim);
        }

        [HttpPost]
        public ActionResult EgitimGetir(TblEgitimlerim t)
        {
            var a = repo.Find(x => x.ID==t.ID);
            a.Baslik = t.Baslik;
            a.Kaynak = t.Kaynak;
            a.AltBaslik = t.AltBaslik;
            a.AltBaslik2 = t.AltBaslik2;
            a.Tarih = t.Tarih;
            a.GNO = t.GNO;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}