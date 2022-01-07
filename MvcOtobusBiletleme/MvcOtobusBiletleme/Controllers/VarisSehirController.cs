using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using MvcOtobusBiletleme.Models.Siniflar;

namespace MvcOtobusBiletleme.Controllers
{
    [Authorize]
    [Authorize(Roles = "A")]
    public class VarisSehirController : Controller
    {
        // GET: VarisSehir
        Context c = new Context();
        public ActionResult Index()
        {
            var varisSehir = c.VarisSehirs.Where(x => x.Durum == true).ToList();
            return View(varisSehir);
        }
        [HttpGet]
        public ActionResult YeniVarisSehir()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniVarisSehir(VarisSehir vs)
        {
            c.VarisSehirs.Add(vs);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult VarisSehirSil(int id)
        {
            var vrshr = c.VarisSehirs.Find(id);
            vrshr.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult VarisSehirGetir(int id)
        {
            var varissehir = c.VarisSehirs.Find(id);
            return View("VarisSehirGetir", varissehir);
        }
        public ActionResult VarisSehirGuncelle(VarisSehir vs)
        {
            var varissehr = c.VarisSehirs.Find(vs.ID);
            varissehr.Durum = vs.Durum;
            varissehr.VarisSehirAd = vs.VarisSehirAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}