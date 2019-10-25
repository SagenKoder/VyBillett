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
            var stationBLL = new StationBLL();
            var stations = stationBLL.GetAllStations();
            return View(stations);
        }

        public ActionResult Delete(int id)
        {
            StationBLL stationBLL = new StationBLL();
            stationBLL.DeleteStation(id);

            return RedirectToAction("Station", "Admin");
        }
    }
}