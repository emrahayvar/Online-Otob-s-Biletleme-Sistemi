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
    public class MarkalarController : Controller
    {
        // GET: Markalar
        Context c = new Context();
        public ActionResult Index()
        {
            var markalar = c.Markalars.Where(x => x.Durum == true).ToList();
            return View(markalar);
        }
        [HttpGet]
        public ActionResult YeniMarkalar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMarkalar(Markalar m)
        {
            c.Markalars.Add(m);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MarkalarSil(int id)
        {
            var deger = c.Markalars.Find(id);
            deger.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MarkalarGetir(int id)
        {
            var marka = c.Markalars.Find(id);
            return View("MarkalarGetir", marka);
        }
        public ActionResult MarkalarGuncelle(Markalar m)
        {
            var mark = c.Markalars.Find(m.ID);
            mark.MarkaAd = m.MarkaAd;
            mark.Durum = m.Durum;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}