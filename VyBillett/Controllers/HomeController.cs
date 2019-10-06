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
            var ticketDTO = new TicketDTO();

            ViewData["adultPrice"] = db.Categories.Where(c => c.CategoryName.Equals("Adult")).FirstOrDefault().CategoryPrice;
            ViewData["studentPrice"] = db.Categories.Where(c => c.CategoryName.Equals("Student")).FirstOrDefault().CategoryPrice;
            ViewData["childPrice"] = db.Categories.Where(c => c.CategoryName.Equals("Child")).FirstOrDefault().CategoryPrice;
            //ticketDTO.Date = DateTime.Now.Date;
            //ticketDTO.Time = DateTime.Now;
            return View(ticketDTO);
        }

        [HttpPost]
        public ActionResult Index(TicketDTO ticket)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Departures", ticket);
            }
            return View(ticket);
        }

        
        public ActionResult Departures(TicketDTO ticketDTO)
        {
            Session["NumAdult"] = ticketDTO.Adult;
            Session["NumStudent"] = ticketDTO.Student;
            Session["NumChild"] = ticketDTO.Child;

            string from = ticketDTO.From.ToLower();
            string to = ticketDTO.To.ToLower();

            DateTime dateTime = new DateTime(
                ticketDTO.Date.Year, 
                ticketDTO.Date.Month, 
                ticketDTO.Date.Day,
                ticketDTO.Time.Hour, 
                ticketDTO.Time.Minute, 0);

            var dateTime30Minutes = new DateTime(dateTime.ToBinary()).AddMinutes(30); // 30 minutes after

            System.Diagnostics.Debug.WriteLine("dateTime " + dateTime);
            System.Diagnostics.Debug.WriteLine("dateTime30Minutes " + dateTime30Minutes);

            var fromStation = db.Stations
                .Where(s => s.Name.ToLower().Equals(from))
                .FirstOrDefault();
            
            var toStation = db.Stations
                .Where(s => s.Name.ToLower().Equals(to))
                .FirstOrDefault();

            List<Line> lines = db.Lines
                .Where(l => l.LineStations.Any(ls => ls.Station.StationId == fromStation.StationId))
                .Where(l => l.LineStations.Any(ls => ls.Station.StationId == toStation.StationId))
                .ToList();

            var travelDepartures = new List<TravelDeparture>();

            foreach (var line in lines)
            {
                System.Diagnostics.Debug.WriteLine("Checking out line " + line.Name);

                LineStation lineStationFrom = db.LineStations
                    .Where(ls => ls.Line.LineId == line.LineId)
                    .Where(ls => ls.Station.StationId == fromStation.StationId)
                    .FirstOrDefault();

                LineStation lineStationTo = db.LineStations
                    .Where(ls => ls.Line.LineId == line.LineId)
                    .Where(ls => ls.Station.StationId == toStation.StationId)
                    .FirstOrDefault();

                System.Diagnostics.Debug.WriteLine("- lineStationFrom - id:" + lineStationFrom.LineStationId + " name:" + lineStationFrom.Station.Name + " line:" + lineStationFrom.Line.Name + " minutes:" + lineStationFrom.Minutes);

                System.Diagnostics.Debug.WriteLine("- lineStationTo - id:" + lineStationTo.LineStationId + " name:" + lineStationTo.Station.Name + " line:" + lineStationTo.Line.Name + " minutes:" + lineStationTo.Minutes);

                if (!(lineStationTo.Minutes > lineStationFrom.Minutes)) continue;

                System.Diagnostics.Debug.WriteLine("- fetching departures....");

                List<Departure> departures = db.Departures
                    .Where(d => d.Line.LineId == line.LineId)
                    .Where(d => d.DateTime.CompareTo(dateTime) > 0)
                    .Where(d => d.DateTime.CompareTo(dateTime30Minutes) < 0)
                    .ToList();

                System.Diagnostics.Debug.WriteLine("- departures - count:" + departures.Count);

                foreach (var departure in departures)
                {
                    System.Diagnostics.Debug.WriteLine("- checking out departure from line " + departure.Line.Name + " date:" + departure.DateTime);

                    DateTime dateFrom = new DateTime(departure.DateTime.ToBinary()).AddMinutes(lineStationFrom.Minutes);
                    DateTime dateTo = new DateTime(departure.DateTime.ToBinary()).AddMinutes(lineStationTo.Minutes);
                    TravelDeparture travelDeparture = new TravelDeparture {
                        StationFrom = fromStation,
                        StationTo = toStation,
                        Departure = departure,
                        DepartureTime = dateFrom,
                        ArrivalTime = dateTo
                    };
                    travelDepartures.Add(travelDeparture);
                }
            }

            ViewData["travelDepartures"] = travelDepartures;
            Session["travelDepartures"] = travelDepartures;

            return View(new DepartureDTO());
        }

        [HttpPost]
        public ActionResult Departures(DepartureDTO departure)
        {
            if (ModelState.IsValid)
            {
                var travelDepartures = Session["travelDepartures"] as List<TravelDeparture>;
                var travelDeparture = travelDepartures[departure.Departure];

                int numAdult = (int) Session["NumAdult"];
                int numStudent = (int)Session["NumStudent"];
                int numChild = (int)Session["NumChild"];

                int priceAdult = db.Categories
                    .Where(c => c.CategoryName.Equals("Adult"))
                    .FirstOrDefault().CategoryPrice;
                int priceStudent = db.Categories
                    .Where(c => c.CategoryName.Equals("Student"))
                    .FirstOrDefault().CategoryPrice;
                int priceChild = db.Categories
                    .Where(c => c.CategoryName.Equals("Child"))
                    .FirstOrDefault().CategoryPrice;

                var totalPrice = numAdult * priceAdult + numStudent * priceStudent + numChild * priceChild;

                Ticket ticket = new Ticket() {
                    From = travelDeparture.StationFrom,
                    To = travelDeparture.StationTo,
                    Departure = travelDeparture.Departure,
                    Price = totalPrice,
                    NumAdult = numAdult,
                    NumStudent = numStudent,
                    NumChild = numChild,
                    Date = DateTime.Now
                };

                db.Tickets.Add(ticket);
                db.SaveChanges();

                return RedirectToAction("Receipt", ticket);
            }

            ViewData["travelDepartures"] = Session["travelDepartures"];

            return View(departure);
        }

        public ActionResult Receipt(Ticket ticket)
        {
            var fromLineStation = db.LineStations
                .Where(ls => ls.Line.LineId == ticket.Departure.Line.LineId)
                .Where(ls => ls.Station.StationId == ticket.From.StationId)
                .FirstOrDefault();

            var toLineStation = db.LineStations
                .Where(ls => ls.Line.LineId == ticket.Departure.Line.LineId)
                .Where(ls => ls.Station.StationId == ticket.To.StationId)
                .FirstOrDefault();

            ViewData["FromLineStation"] = fromLineStation;
            ViewData["ToLineStation"] = toLineStation;

            return View(ticket);
        }
    }
}
