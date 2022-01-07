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
    public class MasrafTipleriController : Controller
    {
        // GET: MasrafTipleri
        Context c = new Context();
        public ActionResult Index()
        {
            var masraftipleri = c.MasrafTipleris.Where(x => x.Durum == true).ToList();
            return View(masraftipleri);
        }
        [HttpGet]
        public ActionResult YeniMasrafTipleri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMasrafTipleri(MasrafTipleri ms)
        {
            c.MasrafTipleris.Add(ms);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MasrafTipleriSil(int id)
        {
            var deger = c.MasrafTipleris.Find(id);
            deger.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MasrafTipleriGetir(int id)
        {
            var masraftip = c.MasrafTipleris.Find(id);
            return View("MasrafTipleriGetir", masraftip);
        }
        public ActionResult MasrafTipleriGuncelle(MasrafTipleri ms)
        {
            var masraf = c.MasrafTipleris.Find(ms.ID);
            masraf.MasrafAd = ms.MasrafAd;
            masraf.Durum = ms.Durum;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}