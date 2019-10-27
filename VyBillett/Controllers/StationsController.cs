using BLL;
using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using BLL;
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
            var stations = _stationBll.GetAllStations();
            return View(stations);
        }

        public ActionResult Delete(int id)
        {
            _stationBll.DeleteStation(id);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Station station = _stationBll.GetStationFromId(id);
            return View(station);
        }

        [HttpPost]
        public ActionResult Edit(Station station)
        {
            _stationBll.EditStation(station.StationId, station);
            return RedirectToAction("Index");
        }

        public ActionResult Add()
        {
            
            return View(new Station());
        }

        [HttpPost]
        public ActionResult Add(Station station)
        {
            System.Diagnostics.Debug.WriteLine("StationsController Add station (Name): " + station.Name);
            _stationBll.Insert(station);
            return RedirectToAction("Index");
        }

        public ActionResult LineStations(int id)
        {
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
            LineStation lineStation = new LineStation();
            var line = _lineBLL.GetLineFromId(id);
            lineStation.Line = line;
            return View(lineStation);
        }
    }
}