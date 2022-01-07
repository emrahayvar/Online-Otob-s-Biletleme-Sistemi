using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOtobusBiletleme.Models.Siniflar;

namespace MvcOtobusBiletleme.Controllers
{
    [Authorize]
    
    public class SeferlerController : Controller
    {
        // GET: Seferler
        Context c = new Context();
        public ActionResult Index()
        {
            var seferler = c.Seferlers.ToList();
            return View(seferler);
        }
        [Authorize(Roles = "A")]
        [HttpGet]
        public ActionResult YeniSeferler()
        {
            List<SelectListItem> degerler1 = (from x in c.Calisanlars.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.Ad + " " + x.Soyad,
                                                  Value = x.ID.ToString()
                                              }).ToList();
            List<SelectListItem> degerler2 = (from x in c.Guzergahs.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.Tanim,
                                                  Value = x.ID.ToString()
                                              }).ToList();
            List<SelectListItem> degerler3 = (from x in c.Otobuslers.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.Plaka,
                                                  Value = x.ID.ToString()
                                              }).ToList();
            List<SelectListItem> degerler4 = (from x in c.KalkisSehirs.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.KalkisSehirAd,
                                                  Value = x.ID.ToString()
                                              }).ToList();
            List<SelectListItem> degerler5 = (from x in c.VarisSehirs.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.VarisSehirAd,
                                                  Value = x.ID.ToString()
                                              }).ToList();
            ViewBag.dgr1 = degerler1;
            ViewBag.dgr2 = degerler2;
            ViewBag.dgr3 = degerler3;
            ViewBag.dgr4 = degerler4;
            ViewBag.dgr5 = degerler5;
            return View();
        }
        [HttpPost]
        public ActionResult YeniSeferler(Seferler s)
        {
            c.Seferlers.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "A")]
        public ActionResult SeferlerGetir(int id)
        {
            List<SelectListItem> degerler1 = (from x in c.Calisanlars.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.Ad + " " + x.Soyad,
                                                  Value = x.ID.ToString()
                                              }).ToList();
            List<SelectListItem> degerler2 = (from x in c.Guzergahs.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.Tanim,
                                                  Value = x.ID.ToString()
                                              }).ToList();
            List<SelectListItem> degerler3 = (from x in c.Otobuslers.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.Plaka,
                                                  Value = x.ID.ToString()
                                              }).ToList();
            List<SelectListItem> degerler4 = (from x in c.KalkisSehirs.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.KalkisSehirAd,
                                                  Value = x.ID.ToString()
                                              }).ToList();
            List<SelectListItem> degerler5 = (from x in c.VarisSehirs.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.VarisSehirAd,
                                                  Value = x.ID.ToString()
                                              }).ToList();
            ViewBag.dgr1 = degerler1;
            ViewBag.dgr2 = degerler2;
            ViewBag.dgr3 = degerler3;
            ViewBag.dgr4 = degerler4;
            ViewBag.dgr5 = degerler5;
            var sfr = c.Seferlers.Find(id);
            return View("SeferlerGetir", sfr);
        }
        public ActionResult SeferlerGuncelle(Seferler s)
        {
            var sefer = c.Seferlers.Find(s.ID);
            sefer.SeferAd = s.SeferAd;
            sefer.KalkisZamani = s.KalkisZamani;
            sefer.VarisZamani = s.VarisZamani;
            sefer.TahminiSure = s.TahminiSure;
            sefer.BiletTutar = s.BiletTutar;
            sefer.Calisanlarid = s.Calisanlarid;
            sefer.Guzergahid = s.Guzergahid;
            sefer.Otobuslerid = s.Otobuslerid;
            sefer.KalkisSehirid = s.KalkisSehirid;
            sefer.VarisSehirid = s.VarisSehirid;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SatisYap(int id)
        {
            
            List<SelectListItem> degerler1 = (from x in c.Calisanlars.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.Ad + " " + x.Soyad,
                                                  Value = x.ID.ToString()
                                              }).ToList();
            ViewBag.dgr1 = degerler1;
            var deger2 = c.Seferlers.Find(id);
            ViewBag.dgr2 = deger2.ID;
            ViewBag.dgr3 = deger2.BiletTutar;
            ViewBag.dgr4 = deger2.KalkisZamani;
            var dpt = c.Seferlers.Where(x => x.ID == id).Select(y => y.SeferAd).FirstOrDefault();
            ViewBag.d = dpt;
            return View();
        }
        [HttpPost]
        public ActionResult SatisYap(Biletler p)
        {
            p.IslemZaman = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.Biletlers.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index", "Biletler");
        }
        public ActionResult SeferlerDetay(int id)
        {
            var degerler = c.Biletlers.Where(x => x.Seferlerid == id).ToList();
            var sef = c.Seferlers.Where(x => x.ID == id).Select(y => y.SeferAd).FirstOrDefault();
            ViewBag.s = sef;
            return View(degerler);
        }



    }
}