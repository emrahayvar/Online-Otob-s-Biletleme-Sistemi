using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOtobusBiletleme.Models.Siniflar;
using PagedList;
using PagedList.Mvc;
namespace MvcOtobusBiletleme.Controllers
{
    [Authorize]
    
    public class SehirlerController : Controller
    {
        // GET: Sehirler
        Context c = new Context();
        public ActionResult Index(int sayfa=1)
        {
            var degerler = c.Sehirlers.Where(x => x.Durum == true).ToList().ToPagedList(sayfa,5);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult SehirEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SehirEkle(Sehirler s)
        {
            c.Sehirlers.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SehirSil(int id)
        {
            var shr = c.Sehirlers.Find(id);
            shr.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SehirGetir(int id)
        {
            var sehir = c.Sehirlers.Find(id);
            return View("SehirGetir", sehir);
        }
        public ActionResult SehirGuncelle(Sehirler s)
        {
            var sehr = c.Sehirlers.Find(s.ID);
            sehr.SehirAd = s.SehirAd;
            sehr.Durum = s.Durum;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}