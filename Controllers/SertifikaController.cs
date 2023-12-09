using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCv.Models.Entity;
using MVCCv.Repositories;

namespace MVCCv.Controllers
{
    public class SertifikaController : Controller
    {
        GenericRepository<TblSertifikalarım> repo = new GenericRepository<TblSertifikalarım> ();

        // GET: Sertifika
        public ActionResult Index()
        {
            var sertifika = repo.List();
            return View(sertifika);
        }

        [HttpGet]
        public ActionResult SertifikaGetir(int id)
        {
            var getir = repo.Find(x=>x.ID == id);
            return View(getir);
        }

        [HttpPost]

        public ActionResult SertifikaGetir(TblSertifikalarım t)
        {
            var sertifika = repo.Find(x=>x.ID==t.ID);
            sertifika.Aciklama = t.Aciklama;
            sertifika.Tarih = t.Tarih;
            repo.TUpdate(sertifika);
            return RedirectToAction("Index");
        }

        [HttpGet]   
        public ActionResult YeniSertifika()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniSertifika(TblSertifikalarım t)
        {
            repo.TAdd(t);
            return RedirectToAction("Index");
        }


        public ActionResult SertifikaSil(int id)
        {
            var y = repo.Find(x=>x.ID==id);
            repo.TDelete(y);
            return RedirectToAction("Index");
        }

    }
}