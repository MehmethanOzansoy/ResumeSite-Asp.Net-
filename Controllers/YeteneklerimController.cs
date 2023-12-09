using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCv.Models.Entity;
using MVCCv.Repositories;

namespace MVCCv.Controllers
{
    public class YeteneklerimController : Controller
    {
        // GET: Yeteneklerim

        YetenekRepository yetenekRepository = new YetenekRepository();

        public ActionResult Index()
        {
            var yetenek = yetenekRepository.List();
            return View(yetenek);
        }

        [HttpGet]
        public ActionResult YetenekEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YetenekEkle(TblYeteneklerim t)
        {
            yetenekRepository.TAdd(t);
            return RedirectToAction("Index");
        }

        public ActionResult YetenekSil(int id)
        {
            TblYeteneklerim t = yetenekRepository.Find(x=>x.ID == id);
            yetenekRepository.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult YetenekGüncelle(int id)
        {
            TblYeteneklerim t = yetenekRepository.Find(x=>x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult YetenekGüncelle(TblYeteneklerim y)
        {
            TblYeteneklerim t = yetenekRepository.Find(x => x.ID == y.ID);
            t.Yetenek = y.Yetenek;
            t.Oran = y.Oran;
            yetenekRepository.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}