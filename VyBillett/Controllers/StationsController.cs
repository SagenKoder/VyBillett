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

        private bool isAuthenticated()
        {
            if (Session["AuthenticatedUser"] == null)
            {
                return false;
            }
            ViewBag.AuthenticatedUser = (DbUser)Session["AuthenticatedUser"];
            return true;
        }

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
            if (!isAuthenticated())
            {
                return RedirectToAction("Index", "Auth");
            }
            var stationBLL = new StationBLL();
            var stations = stationBLL.GetAllStations();
            return View(stations);
        }

        public ActionResult Delete(int id)
        {
            if (!isAuthenticated())
            {
                return RedirectToAction("Index", "Auth");
            }
            StationBLL stationBLL = new StationBLL();
            stationBLL.DeleteStation(id);

            return RedirectToAction("Stations", "Admin");
        }
    }
}
