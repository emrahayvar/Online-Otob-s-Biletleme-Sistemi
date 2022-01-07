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
    public class KalkisSehirController : Controller
    {
        // GET: KalkisSehir
        Context c = new Context();
        public ActionResult Index()
        {
            var kalkisSehir = c.KalkisSehirs.Where(x => x.Durum == true).ToList();
            return View(kalkisSehir);
        }
        [HttpGet]
        public ActionResult YeniKalkisSehir()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKalkisSehir(KalkisSehir ks)
        {
            c.KalkisSehirs.Add(ks);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KalkisSehirSil(int id)
        {
            var klshr = c.KalkisSehirs.Find(id);
            klshr.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KalkisSehirGetir(int id)
        {
            var kalkissehir = c.KalkisSehirs.Find(id);
            return View("KalkisSehirGetir", kalkissehir);
        }
        public ActionResult KalkisSehirGuncelle(KalkisSehir ks)
        {
            var kalkissehr = c.KalkisSehirs.Find(ks.ID);
            kalkissehr.Durum = ks.Durum;
            kalkissehr.KalkisSehirAd = ks.KalkisSehirAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}