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
                zone, HttpContext.Server.MapPath("~/Content/converted.csv"));

            // TODO: refactor this

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

            ViewBag.Results = multiples;
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
