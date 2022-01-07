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
    public class CalisanTypeController : Controller
    {
        // GET: CalisanType
        Context c = new Context();
        public ActionResult Index()
        {
            var calisantype = c.CalisanTypes.Where(x => x.Durum == true).ToList();
            return View(calisantype);
        }
        [HttpGet]
        public ActionResult YeniCalisanType()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniCalisanType(CalisanType ct)
        {
            c.CalisanTypes.Add(ct);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CalisanTypeSil(int id)
        {
            var deger = c.CalisanTypes.Find(id);
            deger.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CalisanTypeGetir(int id)
        {
            var calisantyp = c.CalisanTypes.Find(id);
            return View("CalisanTypeGetir", calisantyp);
        }
        public ActionResult CalisanTypeGuncelle(CalisanType ct)
        {
            var calisan = c.CalisanTypes.Find(ct.ID);
            calisan.TipAd = ct.TipAd;
            calisan.Durum = ct.Durum;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CalisanlarDetay(int id)
        {
            var degerler = c.Calisanlars.Where(x => x.CalisanTypeid == id).ToList();
            var per = c.CalisanTypes.Where(x => x.ID == id).Select(y => y.TipAd).FirstOrDefault();
            ViewBag.p = per;
            return View(degerler);
        }

    }
}