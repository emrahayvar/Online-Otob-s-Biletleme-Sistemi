using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOtobusBiletleme.Models.Siniflar;

namespace MvcOtobusBiletleme.Controllers
{
    [Authorize]
    public class BiletlerController : Controller
    {
        //GET: Biletler
       Context c = new Context();
        public ActionResult Index()
        {
            var biletler = c.Biletlers.ToList();
            return View(biletler);
        }
        [HttpGet]
        public ActionResult YeniBiletler()
        {
            List<SelectListItem> degerler1 = (from x in c.Seferlers.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.SeferAd,
                                                  Value = x.ID.ToString()
                                              }).ToList();
            List<SelectListItem> degerler3 = (from x in c.Calisanlars.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.Ad + " " + x.Soyad,
                                                  Value = x.ID.ToString()
                                              }).ToList();
            ViewBag.dgr1 = degerler1;
            ViewBag.dgr3 = degerler3;
            return View();
        }
        [HttpPost]
        public ActionResult YeniBiletler(Biletler b)
        {
            c.Biletlers.Add(b);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BiletlerGetir(int id)
        {
            List<SelectListItem> degerler1 = (from x in c.Seferlers.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.SeferAd,
                                                  Value = x.ID.ToString()
                                              }).ToList();
            List<SelectListItem> degerler3 = (from x in c.Calisanlars.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.Ad + " " + x.Soyad,
                                                  Value = x.ID.ToString()
                                              }).ToList();
            ViewBag.dgr1 = degerler1;
            ViewBag.dgr3 = degerler3;
            var deger = c.Biletlers.Find(id);
            return View("BiletlerGetir", deger);
        }
        public ActionResult BiletlerGuncelle(Biletler b)
        {
            var bilet = c.Biletlers.Find(b.Biletlerid);           
            bilet.IslemZaman = b.IslemZaman;
            bilet.YolcuCinsiyet = b.YolcuCinsiyet;
            bilet.SatisMiRezarvasyonMu = b.SatisMiRezarvasyonMu;
            bilet.KoltukNo = b.KoltukNo;
            bilet.YolcuAd = b.YolcuAd;
            bilet.YolcuSoyad = b.YolcuSoyad;
            bilet.Ucret = b.Ucret;
            bilet.Calisanlarid = b.Calisanlarid;
            bilet.Musterilerid = b.Musterilerid;
            bilet.Seferlerid = b.Seferlerid;
            bilet.KalkisZamani = b.KalkisZamani;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}