﻿using BLL;
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
            ViewBag.LineId = id;
            return View(departures);
        }

        public ActionResult Add(int id)
        {
            Departure departure = new Departure();
            var line = lineBLL.GetLineFromId(id);
            departure.Line = line;
            departure.DateTime = DateTime.Now;
            return View(departure);
        }

        [HttpPost]
        public ActionResult Add(Departure departure, int id )
        {

            System.Diagnostics.Debug.WriteLine("ID: " + id);
            var lineId = id;
            departure.DepartureId = -1;
            var line = lineBLL.GetLineFromId(id);
            departure.Line = line;
            System.Diagnostics.Debug.WriteLine("Departure LineID: " + departure.Line.LineId);
            System.Diagnostics.Debug.WriteLine("Departure DateTime: " + departure.DateTime);
            departureBLL.Insert(departure);
            return RedirectToAction("Index", new { id = lineId });
        }
        public ActionResult Delete(int id)
        {
            Departure departure = departureBLL.Get(id);

            departureBLL.Delete(id);
            return RedirectToAction("Index", new { id = departure.DepartureId });
        }

    }
}