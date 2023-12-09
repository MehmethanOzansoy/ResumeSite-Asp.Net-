using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCv.Models.Entity;

namespace MVCCv.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default

        DbCvEntities db = new DbCvEntities();
        public ActionResult Index()
        {
            var degerler = db.TblHakkimda.ToList();
            return View(degerler);
        }

        public PartialViewResult Deneyim()
        {
            var deneyimler = db.TblDeneyimlerim.ToList();
            return PartialView(deneyimler);
        }

        public PartialViewResult SosyalMedya()
        {
            var sosyalMedya = db.TblSosyalMedya.ToList();
            return PartialView(sosyalMedya);
        }
        public PartialViewResult Egitimlerim()
        {
            var egitimler = db.TblEgitimlerim.ToList();
            return PartialView(egitimler);
        }

        public PartialViewResult Yeteneklerim()
        {
            var yetenekler = db.TblYeteneklerim.ToList();
            return PartialView(yetenekler);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        public PartialViewResult Hobilerim()
        {
            var hobilerim = db.TblHobilerim.ToList();
            return PartialView(hobilerim);
        }

        public PartialViewResult Sertifikalarım()
        {
            var sertifikalarım = db.TblSertifikalarım.ToList();
            return PartialView(sertifikalarım);
        }
        [HttpGet]
        public PartialViewResult iletisim()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult iletisim(Tbliletisim t)
        {
            t.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.Tbliletisim.Add(t);
            db.SaveChanges();
            return PartialView();
        }
    }
}