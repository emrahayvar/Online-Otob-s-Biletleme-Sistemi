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
    public class GuzergahController : Controller
    {
        // GET: VarisSehir
        Context c = new Context();
        public ActionResult Index()
        {
            var guzergah = c.Guzergahs.Where(x => x.Durum == true).ToList();
            return View(guzergah);
        }
        [HttpGet]
        public ActionResult YeniGuzergah()
        {
            List<SelectListItem> yeniGuzergah = (from x in c.KalkisSehirs.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KalkisSehirAd,
                                               Value = x.ID.ToString()
                                           }).ToList();
            ViewBag.yeniGzg = yeniGuzergah;

            List<SelectListItem> yeniGuzergahh = (from x in c.VarisSehirs.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.VarisSehirAd,
                                                     Value = x.ID.ToString()
                                                 }).ToList();
           
            ViewBag.yeniGzgh = yeniGuzergahh;
            return View();
        }
        [HttpPost]
        public ActionResult YeniGuzergah(Guzergah g)
        {
            c.Guzergahs.Add(g);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GuzergahSil(int id)
        {
            var gzgh = c.Guzergahs.Find(id);
            gzgh.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GuzergahGetir(int id)
        {
            List<SelectListItem> yeniGuzergah = (from x in c.KalkisSehirs.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.KalkisSehirAd,
                                                     Value = x.ID.ToString()
                                                 }).ToList();
            ViewBag.yeniGzg = yeniGuzergah;

            List<SelectListItem> yeniGuzergahh = (from x in c.VarisSehirs.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.VarisSehirAd,
                                               Value = x.ID.ToString()
                                           }).ToList();
            ViewBag.yeniGzgh = yeniGuzergahh;
            var guzergahdeger = c.Guzergahs.Find(id);
            return View("GuzergahGetir", guzergahdeger);
        }
        public ActionResult GuzergahGuncelle(Guzergah gg)
        {
            var gzrghgn = c.Guzergahs.Find(gg.ID);
            gzrghgn.Durum = gg.Durum;
            gzrghgn.Tanim = gg.Tanim;
            gzrghgn.KalkisSehirid = gg.KalkisSehirid;
            gzrghgn.VarisSehirid = gg.VarisSehirid;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}