using MVCCv.Models.Entity;
using MVCCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCv.Controllers
{
    public class HakkımdaController : Controller
    {
        // GET: Hakkımda
        DbCvEntities db = new DbCvEntities();
        GenericRepository<TblHakkimda> tb = new GenericRepository<TblHakkimda>();

        [Authorize]
        [HttpGet]
        public ActionResult Index()
        {
            var hakkimda = tb.List();
            return View(hakkimda);
        }

        [HttpPost]
        public ActionResult Index(TblHakkimda hakkimda)
        {
            var t = tb.Find(x=>x.ID == 1);
            t.Ad = hakkimda.Ad;
            t.Soyad = hakkimda.Soyad;
            t.Adres = hakkimda.Adres;
            t.Telefon = hakkimda.Telefon;
            t.Mail = hakkimda.Mail;
            t.Aciklama = hakkimda.Aciklama;
            t.Resim = hakkimda.Resim;
            tb.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}