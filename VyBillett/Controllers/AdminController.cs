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
        IUserBLL userBLL = new UserBLL();
        IStationBLL stationBLL = new StationBLL();
        ILineBLL lineBLL = new LineBLL();
        IDepartureBLL departureBLL = new DepartureBLL();
        ITicketBLL ticketBLL = new TicketBLL();

        public AdminController()
        {
            userBLL = new UserBLL();
            stationBLL = new StationBLL();
            lineBLL = new LineBLL();
            departureBLL = new DepartureBLL();
            ticketBLL = new TicketBLL();
        }

        public AdminController(IUserBLL userBLL, IStationBLL stationBLL, ILineBLL lineBLL, IDepartureBLL departureBLL, ITicketBLL ticketBLL)
        {
            this.userBLL = userBLL;
            this.stationBLL = stationBLL;
            this.lineBLL = lineBLL;
            this.departureBLL = departureBLL;
            this.ticketBLL = ticketBLL;
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
