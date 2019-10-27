using BLL;
using DAL;
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
    public class StationsController : Controller
    {
        private readonly IStationBLL _stationBll;

        private readonly ILineBLL _lineBLL;

        public StationsController()
        {
            _stationBll = new StationBLL();
        }

        public StationsController(IStationBLL stationBll)
        {
            _stationBll = stationBll;
        }
        
        public ActionResult Index()
        {
            if (!isAuthenticated())
            {
                return RedirectToAction("Index", "Auth");
            }
            var stations = _stationBll.GetAllStations();
            return View(stations);
        }

        public ActionResult Delete(int id)
        {
            if (!isAuthenticated())
            {
                return RedirectToAction("Index", "Auth");
            }
            _stationBll.DeleteStation(id);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            if (!isAuthenticated())
            {
                return RedirectToAction("Index", "Auth");
            }
            Station station = _stationBll.GetStationFromId(id);
            return View(station);
        }

        [HttpPost]
        public ActionResult Edit(Station station)
        {
            if (!isAuthenticated())
            {
                return RedirectToAction("Index", "Auth");
            }
            _stationBll.EditStation(station.StationId, station);
            return RedirectToAction("Index");
        }

        public ActionResult Add()
        {
            if (!isAuthenticated())
            {
                return RedirectToAction("Index", "Auth");
            }
            return View(new Station());
        }

        [HttpPost]
        public ActionResult Add(Station station)
        {
            if (!isAuthenticated())
            {
                return RedirectToAction("Index", "Auth");
            }
            System.Diagnostics.Debug.WriteLine("StationsController Add station (Name): " + station.Name);
            _stationBll.Insert(station);
            return RedirectToAction("Index");
        }

        public ActionResult LineStations(int id)
        {
            if (!isAuthenticated())
            {
                return RedirectToAction("Index", "Auth");
            }
            List<LineStation> lineStations = _stationBll.GetFromLineId(id);
            foreach (LineStation lineStation in lineStations)
            {
                System.Diagnostics.Debug.WriteLine(lineStation.Minutes);
                System.Diagnostics.Debug.WriteLine("LineStation.Line: " + lineStation.Line);

                System.Diagnostics.Debug.WriteLine(lineStation.Line.Name);
                System.Diagnostics.Debug.WriteLine(lineStation.Station.Name);
            }

            ViewBag.LineId = id;
            Session["lineId"] = id;
            return View(lineStations);
        }

        public ActionResult AddLineStation(int id)
        {

            if (!isAuthenticated())
            {
                return RedirectToAction("Index", "Auth");
            }

            ViewBag.LineId = id;
            LineStation lineStation = new LineStation();
            return View(lineStation);
        }

        private bool isAuthenticated()
        {
            if (Session["AuthenticatedUser"] == null)
            {
                return false;
            }
            ViewBag.AuthenticatedUser = (DbUser)Session["AuthenticatedUser"];
            return true;
        }
    }
}