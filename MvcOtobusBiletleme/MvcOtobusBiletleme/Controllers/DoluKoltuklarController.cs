using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOtobusBiletleme.Models.Siniflar;

namespace MvcOtobusBiletleme.Controllers
{
    [Authorize]
    public class DoluKoltuklarController : Controller
    {
        Context c = new Context();
        // GET: DoluKoltuklar
        public ActionResult Index()
        {
            var dolukoltuklar = c.DoluKoltuklars.ToList();
            return View(dolukoltuklar);
        }
        [HttpGet]
        public ActionResult YeniDoluKoltuklar()
        {
            List<SelectListItem> degerler1 = (from x in c.Seferlers.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.SeferAd,
                                                  Value = x.ID.ToString()
                                              }).ToList();
            ViewBag.dgr1 = degerler1;
            List<SelectListItem> degerler2 = (from x in c.KalkisSehirs.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.KalkisSehirAd,
                                                  Value = x.ID.ToString()
                                              }).ToList();
            ViewBag.dgr2 = degerler2;
            return View();
        }
        [HttpPost]
        public ActionResult YeniDoluKoltuklar(DoluKoltuklar dk)
        {
            c.DoluKoltuklars.Add(dk);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DoluKoltuklarGetir(int id)
        {
            List<SelectListItem> degerler1 = (from x in c.Seferlers.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.SeferAd,
                                                  Value = x.ID.ToString()
                                              }).ToList();
            List<SelectListItem> degerler2 = (from x in c.KalkisSehirs.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.KalkisSehirAd,
                                                  Value = x.ID.ToString()
                                              }).ToList();
            ViewBag.dgr1 = degerler1;
            ViewBag.dgr2 = degerler2;

            var dolukol = c.DoluKoltuklars.Find(id);
            return View("DoluKoltuklarGetir", dolukol);
        }
        public ActionResult DoluKoltuklarGuncelle(DoluKoltuklar dk)
        {
            var dolukoltk = c.DoluKoltuklars.Find(dk.KoltukID);
            dolukoltk.KalkisZamani = dk.KalkisZamani;
            dolukoltk.BiletNo = dk.BiletNo;
            dolukoltk.Seferlerid = dk.Seferlerid;
            dolukoltk.KalkisSehirid = dk.KalkisSehirid;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}