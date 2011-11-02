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

            ViewBag.GivenZone = TzTimeZone.GetTimeZone(givenZone.ZoneName);

            return View();
        }

    }
}
