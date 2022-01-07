using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOtobusBiletleme.Models.Siniflar;
namespace MvcOtobusBiletleme.Controllers
{
    [Authorize]
    public class DoluKoltukController : Controller
    {
        // GET: DoluKoltuk
        Context c = new Context();
        public ActionResult Index()
        {
            var dolukoltuk = c.Biletlers.ToList();
            return View(dolukoltuk);
        }
    }
}