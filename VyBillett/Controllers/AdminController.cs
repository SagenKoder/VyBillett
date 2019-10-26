using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VyBillett.Models;
using System.Web.Script.Serialization;
using BLL;
using Model;

namespace VyBillett.Controllers
{
    public class AdminController : Controller
    {
        UserBLL userBLL = new UserBLL();
        StationBLL stationBLL = new StationBLL();
        LineBLL lineBLL = new LineBLL();
        DepartureBLL departureBLL = new DepartureBLL();
        TicketBLL ticketBLL = new TicketBLL();

        private bool isAuthenticated()
        {
            if (Session["AuthenticatedUser"] == null)
            {
                return false;
            }
            ViewBag.AuthenticatedUser = (DbUser)Session["AuthenticatedUser"];
            return true;
        }

        // GET: Admin
        public ActionResult Index()
        {
            if (!isAuthenticated())
            {
                return RedirectToAction("Index", "Auth");
            }
            StatisticsDTO statisticsDTO = new StatisticsDTO();
            statisticsDTO.NumUsers = userBLL.Count();
            statisticsDTO.NumStations = stationBLL.Count();
            statisticsDTO.NumLines = lineBLL.Count();
            statisticsDTO.NumDepartures = departureBLL.Count();
            statisticsDTO.NumTickets = ticketBLL.Count();
            return View(statisticsDTO);
        }
    }
}
