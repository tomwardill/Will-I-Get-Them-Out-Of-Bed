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
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {



            return RedirectToAction("Lookup", "City", new { zone = collection["city"] });
        }
    }
}
