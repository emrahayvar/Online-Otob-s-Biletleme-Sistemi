using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOtobusBiletleme.Models.Siniflar;

namespace MvcOtobusBiletleme.Controllers
{
    [Authorize]
    [Authorize(Roles = "A")]
    public class OtobuslerController : Controller
    {
        // GET: Otobusler
        Context c = new Context();
        public ActionResult Index()
        {
            var otobusler = c.Otobuslers.Where(x => x.AktifMi == true).ToList();
            return View(otobusler);
        }
        [HttpGet]
        public ActionResult YeniOtobusler()
        {
            List<SelectListItem> degerler1 = (from x in c.Markalars.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.MarkaAd,
                                                  Value = x.ID.ToString()
                                              }).ToList();
            ViewBag.dgr1 = degerler1;
            return View();
        }
        [HttpPost]
        public ActionResult YeniOtobusler(Otobusler o)
        {
            c.Otobuslers.Add(o);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult OtobuslerSil(int id)
        {
            var deger = c.Otobuslers.Find(id);
            deger.AktifMi = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult OtobusGetir(int id)
        {
            List<SelectListItem> degerler1 = (from x in c.Markalars.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.MarkaAd,
                                                  Value = x.ID.ToString()
                                              }).ToList();
            ViewBag.dgr1 = degerler1;
            var otobs = c.Otobuslers.Find(id);
            return View("OtobusGetir", otobs);
        }
        public ActionResult OtobuslerGuncelle(Otobusler o)
        {
            var oto = c.Otobuslers.Find(o.ID);
            oto.Plaka = o.Plaka;
            oto.KoltukSayisi = o.KoltukSayisi;
            oto.Markalarid = o.Markalarid;
            oto.AktifMi = o.AktifMi;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}