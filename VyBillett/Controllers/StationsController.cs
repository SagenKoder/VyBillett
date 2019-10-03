using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using VyBillett.Models;

namespace VyBillett.Controllers
{
    public class StationsController : Controller
    {
        private Db db = new Db();

        protected override void Dispose(bool disposing)
        {
            // Denne vil dispose dbContext etter view´et er rendret ferdig!
            // Slik kan vi aksessere alleKundene via lazy loading der.
            // Dette har ikke noe med ToList() å gjøre.
            // Ved bruk av Using vil vi noen ganger få problemer med dette.
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // GET: Stations
        public string Index()
        {
            var stasjoner = db.Stations.ToList();

            if (stasjoner.Count < 1)
            {
                return "";
            }

            var serializer = new JavaScriptSerializer();
            return serializer.Serialize(stasjoner);
        }

        public string GetStations()
        {
            return "Fra GetStations";
        }
    }
}