using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PublicDomain;

namespace willigetthemoutofbed.Controllers
{
    public class CityController : Controller
    {
        //
        // GET: /City/

        public ActionResult Lookup(string zone)
        {

            ViewBag.City = zone;

            var givenZone = (from availableZone in TzTimeZone.ZoneList where availableZone.ZoneName == zone select availableZone).Single();

            var timeZone = TzTimeZone.GetTimeZone(givenZone.ZoneName);
            ViewBag.givenZone = timeZone;

            ViewBag.Result = false;
            if (timeZone.Now.DateTimeLocal.Hour < 8 || timeZone.Now.DateTimeLocal.Hour > 21)
            {
                ViewBag.Result = true;
            }

            return View();
        }

    }
}
