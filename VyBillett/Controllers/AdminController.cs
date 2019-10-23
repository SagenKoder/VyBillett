using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VyBillett.Models;
using System.Web.Script.Serialization;

namespace VyBillett.Controllers
{
    public class AdminController : Controller
    {

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Stations()
        {
       
            //var stations = db.Stations.ToList();
            return View(stations);

        }
    }
}