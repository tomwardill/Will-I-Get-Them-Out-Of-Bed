using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PublicDomain;

namespace willigetthemoutofbed.Controllers
{
    using System.IO;

    public class CityController : Controller
    {
        //
        // GET: /City/

        public ActionResult Lookup(string zone)
        {

            ViewBag.City = zone;

            var lookupZone = this.LookupCity(
                zone, Path.Combine(HttpContext.Request.PhysicalApplicationPath, "App_Data/converted.csv"));

            if (lookupZone.Count() == 1)
            {
                var givenZone = lookupZone[0];
                ViewBag.givenZone = givenZone;
                ViewBag.Result = false;
                if (givenZone.Now.DateTimeLocal.Hour < 8 || givenZone.Now.DateTimeLocal.Hour > 21)
                {
                    ViewBag.Result = true;
                }

                ViewBag.Multiple = false;
                return View();
            }
            if (lookupZone.Count() > 1)
            {
                ViewBag.Multiple = true;

                var multiples = new Dictionary<TzTimeZone, bool>();

                foreach (var zoneResult in lookupZone)
                {
                    var result = false;
                    if (zoneResult.Now.DateTimeLocal.Hour < 8 || zoneResult.Now.DateTimeLocal.Hour > 21)
                    {
                        result = true;
                    }
                    multiples[zoneResult] = result;
                }

                ViewBag.MultipleResults = multiples;
                return this.View("MultipleLookup");
            }

            return this.View();
        }

        private List<PublicDomain.TzTimeZone> LookupCity(string cityName, string filepath)
        {
            var lines = System.IO.File.ReadAllLines(filepath);
            var timezone =
                 from line in lines
                 let x = line.Split(',')
                 where string.Equals(x[0].ToLower(), cityName.ToLower())
                 select TzTimeZone.GetTimeZone(x[1].Trim());

            return timezone.ToList();
        }

    }
}
