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
            return View();
        }
    }
}