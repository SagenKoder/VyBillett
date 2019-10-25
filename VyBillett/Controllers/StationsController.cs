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
        private VyDbContext db = new VyDbContext();
        private StationBLL stationBLL = new StationBLL();

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // GET: Stations
        
        public ActionResult Index()
        {
            var stations = stationBLL.GetAllStations();
            return View(stations);
        }

        public ActionResult Delete(int id)
        {
            stationBLL.DeleteStation(id);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Station station = stationBLL.GetStationFromId(id);
            return View(station);
        }

        [HttpPost]
        public ActionResult Edit(Station station)
        {
            stationBLL.EditStation(station.StationId, station);
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
            stationBLL.Insert(station);
            return RedirectToAction("Index");
        }
    }
}