using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOtobusBiletleme.Models.Siniflar;


namespace MvcOtobusBiletleme.Controllers
{
    [Authorize]
    public class MusterilerController : Controller
    {
        // GET: Musteriler
        Context c = new Context();
        public ActionResult Index()
        {
            var musteriler = c.Musterilers.ToList();
            return View(musteriler);
        }
        [HttpGet]
        public ActionResult YeniMusteriler()
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
        public ActionResult YeniMusteriler(Musteriler m)
        {
            c.Musterilers.Add(m);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusterilerGetir(int id)
        {
            List<SelectListItem> degerler1 = (from x in c.Sehirlers.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.SehirAd,
                                                  Value = x.ID.ToString()
                                              }).ToList();
            ViewBag.dgr1 = degerler1;
            var musteri = c.Musterilers.Find(id);
            return View("MusterilerGetir", musteri);
        }
        public ActionResult MusterilerGuncelle(Musteriler m)
        {
            var mus = c.Musterilers.Find(m.ID);
            mus.Ad = m.Ad;
            mus.Soyad = m.Soyad;
            mus.Telefon = m.Telefon;
            mus.Cinsiyet = m.Cinsiyet;
            mus.DogumTarih = m.DogumTarih;
            mus.Sehirlerid = m.Sehirlerid;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriListesi()
        {
            var degerler = c.Musterilers.ToList();
            return View(degerler);
        }
    }
}