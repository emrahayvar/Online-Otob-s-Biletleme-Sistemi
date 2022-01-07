using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcOtobusBiletleme.Models.Siniflar;


namespace MvcOtobusBiletleme.Controllers
{
    [Authorize]
    public class MusteriPanelController : Controller
    {
        // GET: MusteriPanel
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult SeferSec()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SeferSec(KalkisSehir p, VarisSehir l)
        {
            var bilgiler = c.Seferlers.FirstOrDefault(x => x.KalkisSehir.KalkisSehirAd == p.KalkisSehirAd && x.VarisSehir.VarisSehirAd == l.VarisSehirAd);
            if (bilgiler != null)
            {
                return RedirectToAction("Index", "Seferler");
            }
            else
            {
                return RedirectToAction("Index", "MusteriPanel");
            }
        }
    }
}