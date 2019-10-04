using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VyBillett.Models;

namespace VyBillett.Controllers
{
    public class HomeController : Controller
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

        public ActionResult Index()
        {
            ViewData["stations"] = db.Stations.ToList();
            return View(new TicketDTO());
        }

        [HttpPost]
        public ActionResult Index(TicketDTO ticket)
        {
            if (ModelState.IsValid)
            {
                TempData["ticketDTO"] = ticket;
                return RedirectToAction("Departures");
            }
            return View(ticket);
        }

        public ActionResult Departures()
        {
            //var ticketDTO = TempData["ticketDTO"] as TicketDTO;
            //var ticket = new Ticket { From = db.Stations.Where(t => t.Name == ticketDTO.From).FirstOrDefault(), To = db.Stations.Where(t => t.Name == ticketDTO.To).FirstOrDefault() };

            var ticketDTO = TempData["ticketDTO"] as TicketDTO;
            string from = ticketDTO.From.ToLower();
            string to = ticketDTO.To.ToLower();
            DateTime date = ticketDTO.Date;
            DateTime time = ticketDTO.Time;

            var fromStation = db.Stations.Where(s => s.Name.ToLower().Equals(from)).FirstOrDefault();
            var toStation = db.Stations.Where(s => s.Name.ToLower().Equals(to)).FirstOrDefault();

            ViewData["fromStation"] = fromStation;
            ViewData["toStation"] = toStation;

            List<Line> lines = db.Lines
                .Where(l => l.LineStations.Any(ls => ls.Station.StationId == fromStation.StationId || ls.Station.StationId == toStation.StationId))
                .ToList();

            return View();
        }

        [HttpPost]
        public ActionResult Departures(Departure departure)
        {
            if (ModelState.IsValid)
            {
                var ticketDTO = TempData["ticketDTO"] as TicketDTO;
                var from = db.Stations.Where(s => s.Name.ToLower().Equals(ticketDTO.From)).FirstOrDefault();
                var to = db.Stations.Where(s => s.Name.ToLower().Equals(ticketDTO.To)).FirstOrDefault();

                db.Tickets.Add(new Ticket { 
                    From = from,
                    To = to,
                    Departure = departure
                });
                return RedirectToAction("Success");
            }
            return RedirectToAction("Error");
        }

        public ActionResult FindDepartures()
        {
            using (var db = new Models.Db())
            {

            }
            return View();
        }
    }
}