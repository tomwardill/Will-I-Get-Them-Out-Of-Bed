using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace willigetthemoutofbed.Controllers
{
    using System.Text;

    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("var zones = [\n");
            foreach (var zone in PublicDomain.TzTimeZone.AllZoneNames)
            {
                sb.Append("\"" + zone + "\",\n");
            }
            sb.Append("]");

            ViewBag.Zones = sb.ToString();

            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {



            return RedirectToAction("Lookup", "City", new { zone = collection["city"] });
        }
    }
}
