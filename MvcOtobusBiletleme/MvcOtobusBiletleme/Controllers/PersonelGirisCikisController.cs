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
    public class PersonelGirisCikisController : Controller
    {
        // GET: PersonelGirisCikis
        Context c = new Context();
        public ActionResult Index()
        {
            var personel = c.PersonelGirisCikis1.ToList();
            return View(personel);
        }
        [HttpGet]
        public ActionResult YeniPersonelGirisCikis()
        {
            List<SelectListItem> degerler1 = (from x in c.Calisanlars.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.Ad + " " + x.Soyad,
                                                  Value = x.ID.ToString()
                                              }).ToList();
            ViewBag.dgr1 = degerler1;
            return View();
        }
        [HttpPost]
        public ActionResult YeniPersonelGirisCikis(PersonelGirisCikis pg)
        {
            c.PersonelGirisCikis1.Add(pg);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelGirisCikisGetir(int id)
        {
            List<SelectListItem> degerler1 = (from x in c.Calisanlars.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.Ad + " " + x.Soyad,
                                                  Value = x.ID.ToString()
                                              }).ToList();
            ViewBag.dgr1 = degerler1;
            var giriscikis = c.PersonelGirisCikis1.Find(id);
            return View("PersonelGirisCikisGetir", giriscikis);
        }
        public ActionResult PersonelGirisCikisGuncelle(PersonelGirisCikis pg)
        {
            var person = c.PersonelGirisCikis1.Find(pg.ID);
            person.Calisanlarid = pg.Calisanlarid;
            person.Giris = pg.Giris;
            person.Cikis = pg.Cikis;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}