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
    public class SubelerController : Controller
    {
        // GET: Subeler
        Context c = new Context();
        public ActionResult Index()
        {
            var sube = c.Subelers.Where(x => x.Durum == true).ToList();
            return View(sube);
        }
        [HttpGet]
        public ActionResult YeniSubeler()
        {
            List<SelectListItem> degerler1 = (from x in c.Sehirlers.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.SehirAd,
                                                  Value = x.ID.ToString()
                                              }).ToList();
            ViewBag.dgr1 = degerler1;
            return View();
        }
        [HttpPost]
        public ActionResult YeniSubeler(Subeler s)
        {
            c.Subelers.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SubelerSil(int id)
        {
            var deger = c.Subelers.Find(id);
            deger.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SubelerGetir(int id)
        {
            List<SelectListItem> degerler1 = (from x in c.Sehirlers.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.SehirAd,
                                                  Value = x.ID.ToString()
                                              }).ToList();
            ViewBag.dgr1 = degerler1;
            var deger = c.Subelers.Find(id);
            return View("SubelerGetir", deger);
        }
        public ActionResult SubelerGuncelle(Subeler s)
        {
            var sub = c.Subelers.Find(s.ID);
            sub.SubeAd = s.SubeAd;
            sub.Sehirlerid = s.Sehirlerid;
            sub.Durum = s.Durum;
            c.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}