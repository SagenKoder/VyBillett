using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VyBillett.Controllers
{
    public class DepartureController : Controller
    {
        DepartureBLL departureBLL = new DepartureBLL();
        LineBLL lineBLL = new LineBLL();
        // GET: Departure
        public ActionResult Index(int id)
        {
            var departures = departureBLL.GetFromLineId(id);
            return View(departures);
        }

        public ActionResult Add(int id)
        {
            Departure departure = new Departure();
            var line = lineBLL.GetLineFromId(id);
            departure.Line = line;

            return View(departure);
        }

        [HttpPost]
        public ActionResult Add(int id, Departure departure)
        {
            var line = lineBLL.GetLineFromId(id);
            departure.Line = line;
            departureBLL.Insert(departure);
            return RedirectToAction("Index");
        }
    }
}