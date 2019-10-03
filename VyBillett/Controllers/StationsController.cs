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

        [HttpGet]
        public string GetDestinations(string name)
        {
            Station station = db.Stations
                .Where(i => i.Name.ToLower().Equals(name.ToLower()))
                .FirstOrDefault();
            if (station != null)
            {
                List<Line> lines = db.Lines
                    .Where(i => i.LineStations.Any(ss => ss.Station.StationId == station.StationId))
                    .Distinct()
                    .ToList();
                List<Station> stations = new List<Station>();

                foreach (var line in lines)
                {
                    stations.AddRange(db.Stations
                        .Where(ss => ss.LineStations.Any(s => s.Line.LineId == line.LineId))
                        .Where(ss => ss.StationId != station.StationId)
                        .Distinct()
                        .ToList()); ;
                }

                var serializer = new JavaScriptSerializer();

                return serializer.Serialize(stations);
            }
            return "[]";
        }
    }
}