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
    public class OtobusMasraflariController : Controller
    {
        // GET: OtobusMasraflari
        Context c = new Context();
        public ActionResult Index()
        {
            var otobusmasraflari = c.OtobusMasraflaris.ToList();
            return View(otobusmasraflari);
        }
        [HttpGet]
        public ActionResult YeniOtobusMasraflari()
        {
            List<SelectListItem> degerler1 = (from x in c.Seferlers.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.SeferAd,
                                                  Value = x.ID.ToString()
                                              }).ToList();
            List<SelectListItem> degerler2 = (from x in c.Otobuslers.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.Plaka,
                                                  Value = x.ID.ToString()
                                              }).ToList();
            List<SelectListItem> degerler3 = (from x in c.Calisanlars.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.Ad + " " + x.Soyad,
                                                  Value = x.ID.ToString()
                                              }).ToList();
            List<SelectListItem> degerler4 = (from x in c.MasrafTipleris.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.MasrafAd,
                                                  Value = x.ID.ToString()
                                              }).ToList();    
            ViewBag.dgr1 = degerler1;
            ViewBag.dgr2 = degerler2;
            ViewBag.dgr3 = degerler3;
            ViewBag.dgr4 = degerler4;
            return View();
        }
        [HttpPost]
        public ActionResult YeniOtobusMasraflari(OtobusMasraflari om)
        {
            c.OtobusMasraflaris.Add(om);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult OtobusMasraflariGetir(int id)
        {
            List<SelectListItem> degerler1 = (from x in c.Seferlers.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.SeferAd,
                                                  Value = x.ID.ToString()
                                              }).ToList();
            List<SelectListItem> degerler2 = (from x in c.Otobuslers.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.Plaka,
                                                  Value = x.ID.ToString()
                                              }).ToList();
            List<SelectListItem> degerler3 = (from x in c.Calisanlars.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.Ad + " " + x.Soyad,
                                                  Value = x.ID.ToString()
                                              }).ToList();
            List<SelectListItem> degerler4 = (from x in c.MasrafTipleris.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.MasrafAd,
                                                  Value = x.ID.ToString()
                                              }).ToList();            
            ViewBag.dgr1 = degerler1;
            ViewBag.dgr2 = degerler2;
            ViewBag.dgr3 = degerler3;
            ViewBag.dgr4 = degerler4;
            var otobusmas = c.OtobusMasraflaris.Find(id);
            return View("OtobusMasraflariGetir", otobusmas);
        }
        public ActionResult OtobusMasraflariGuncelle(OtobusMasraflari om)
        {
            var otobus = c.OtobusMasraflaris.Find(om.ID);
            otobus.Seferlerid = om.Seferlerid;
            otobus.Otobuslerid = om.Otobuslerid;            
            otobus.Calisanlarid = om.Calisanlarid;
            otobus.MasrafTipleriid = om.MasrafTipleriid;
            otobus.Tutar = om.Tutar;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}