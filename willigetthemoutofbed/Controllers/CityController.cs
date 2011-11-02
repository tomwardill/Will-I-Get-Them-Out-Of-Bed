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

        public ActionResult Lookup(string id)
        {
            ViewBag.City = id;

            var availableTimeZones = TimeZoneInfo.GetSystemTimeZones();
            Dictionary<string, TimeZoneInfo> data = new Dictionary<string, TimeZoneInfo>();

            foreach (var zone in availableTimeZones)
            {
                var names = zone.ToString().Split(')')[1];
                foreach (var name in names.Split(','))
                {
                    data[name.ToLower().Trim()] = zone;
                }
            }

            var givenZone = data[id.ToLower()];

            ViewBag.GivenZone = givenZone;

            return View();
        }

    }
}
