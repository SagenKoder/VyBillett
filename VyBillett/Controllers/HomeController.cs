﻿using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using VyBillett.Models;

namespace VyBillett.Controllers
{
    public class HomeController : Controller
    {
        private VyDbContext db = new VyDbContext();

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Index()
        {

            ViewData["stations"] = db.Stations.ToList();
            var ticketDto = new TicketDTO();

            ViewData["adultPrice"] = db.Categories.FirstOrDefault(c => c.CategoryName.Equals("Adult")).CategoryPrice;
            ViewData["studentPrice"] = db.Categories.FirstOrDefault(c => c.CategoryName.Equals("Student")).CategoryPrice;
            ViewData["childPrice"] = db.Categories.FirstOrDefault(c => c.CategoryName.Equals("Child")).CategoryPrice;
            return View(ticketDto);
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
                .FirstOrDefault(s => s.Name.ToLower().Equals(@from));
            
            var toStation = db.Stations
                .FirstOrDefault(s => s.Name.ToLower().Equals(to));

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
                    .FirstOrDefault(ls => ls.Station.StationId == fromStation.StationId);

                LineStation lineStationTo = db.LineStations
                    .Where(ls => ls.Line.LineId == line.LineId)
                    .FirstOrDefault(ls => ls.Station.StationId == toStation.StationId);

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
        [ValidateAntiForgeryToken]
        public ActionResult Departures(DepartureDTO departure)
        {

            if (ModelState.IsValid)
            {
                var travelDepartures = Session["travelDepartures"] as List<TravelDeparture>;
                var travelDeparture = travelDepartures[departure.DepartureId];

                int numAdult = (int) Session["NumAdult"];
                int numStudent = (int)Session["NumStudent"];
                int numChild = (int)Session["NumChild"];

                int priceAdult = db.Categories
                    .FirstOrDefault(c => c.CategoryName.Equals("Adult")).CategoryPrice;
                int priceStudent = db.Categories
                    .FirstOrDefault(c => c.CategoryName.Equals("Student")).CategoryPrice;
                int priceChild = db.Categories
                    .FirstOrDefault(c => c.CategoryName.Equals("Child")).CategoryPrice;

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

                Session["BoughtTicket"] = ticket;

                return RedirectToAction("Receipt");
            }

            ViewData["travelDepartures"] = Session["travelDepartures"];

            return View(departure);
        }

        public ActionResult Receipt()
        {

            Ticket ticket = (Ticket) Session["BoughtTicket"];

            var fromLineStation = db.LineStations
                .Where(ls => ls.Line.LineId == ticket.Departure.Line.LineId)
                .FirstOrDefault(ls => ls.Station.StationId == ticket.From.StationId);

            var toLineStation = db.LineStations
                .Where(ls => ls.Line.LineId == ticket.Departure.Line.LineId)
                .FirstOrDefault(ls => ls.Station.StationId == ticket.To.StationId);

            ViewData["FromLineStation"] = fromLineStation;
            ViewData["ToLineStation"] = toLineStation;

            return View(ticket);
        }

        public string ListStations()
        {
            var stasjoner = db.Stations.OrderBy(s => s.Name).ToList();

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
                    var lineStation = db.LineStations
                        .Where(ls => ls.Line.LineId == line.LineId)
                        .Where(ls => ls.Station.StationId == station.StationId)
                        .FirstOrDefault();

                    stations.AddRange(db.Stations
                        .Where(ss => ss.LineStations.Any(s => s.Line.LineId == line.LineId && s.Minutes > lineStation.Minutes))
                        .Distinct()
                        .OrderBy(ss => ss.Name)
                        .ToList());
                }

                stations = stations.OrderBy(s => s.Name).ToList();
                stations = stations.Distinct().ToList();

                var serializer = new JavaScriptSerializer();

                return serializer.Serialize(stations);
            }
            return "[]";
        }

    }
}
