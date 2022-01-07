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
    public class CalisanlarController : Controller
    {
        // GET: Calisanlar
        Context c = new Context();
        public ActionResult Index()
        {
            var calisanlar = c.Calisanlars.Where(x=>x.Durum==true).ToList();
            return View(calisanlar);
        }
        [HttpGet]
        public ActionResult YeniCalisanlar()
        {
            List<SelectListItem> degerler1 = (from x in c.CalisanTypes.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.TipAd,
                                                  Value = x.ID.ToString()
                                              }).ToList();

            List<SelectListItem> degerler2 = (from x in c.Subelers.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.SubeAd,
                                                  Value = x.ID.ToString()
                                              }).ToList();
            ViewBag.dgr1 = degerler1;
            ViewBag.dgr2 = degerler2;
            return View();
        }
        [HttpPost]
        public ActionResult YeniCalisanlar(Calisanlar ca)
        {
            c.Calisanlars.Add(ca);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CalisanlarSil(int id)
        {
            var calisanlar = c.Calisanlars.Find(id);
            calisanlar.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CalisanlarGetir(int id)
        {
            List<SelectListItem> degerler1 = (from x in c.CalisanTypes.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.TipAd,
                                                  Value = x.ID.ToString()
                                              }).ToList();
            List<SelectListItem> degerler2 = (from x in c.Subelers.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.SubeAd,
                                                  Value = x.ID.ToString()
                                              }).ToList();
            ViewBag.dgr1 = degerler1;
            ViewBag.dgr2 = degerler2;
            var calis = c.Calisanlars.Find(id);
            return View("CalisanlarGetir", calis);
        }
        public ActionResult CalisanlarGuncelle(Calisanlar ca)
        {
            var cal = c.Calisanlars.Find(ca.ID);
            cal.Ad = ca.Ad;
            cal.Soyad = ca.Soyad;
            cal.Telefon = ca.Telefon;
            cal.Email = ca.Email;
            cal.EvAdres = ca.EvAdres;
            cal.KullaniciAd = ca.KullaniciAd;
            cal.Sifre = ca.Sifre;
            cal.CalisanTypeid = ca.CalisanTypeid;
            cal.Subelerid = ca.Subelerid;
            cal.Durum = cal.Durum;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}