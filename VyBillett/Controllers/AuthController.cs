using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using VyBillett.Models;
using BLL;

namespace VyBillett.Controllers
{
    public class AuthController : Controller
    {
        public ActionResult Index()
        {
            isAuthenticated();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(User user)
        {
            var userBLL = new UserBLL();
            var dbUser = userBLL.AuthenticateAndGetUserIfOk(user.Username, user.Password);

            if (dbUser != null)
            {
                authenticateUser(dbUser);
                return View();
            }
            else
            {
                deauthenticateUser();
                return View();
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var userBLL = new UserBLL();

            var createdUser = userBLL.CreateNewUser(user.Username, user.Password);
            if (createdUser == null)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            deauthenticateUser();
            return RedirectToAction("Index", "Auth");
        }

        private bool isAuthenticated()
        {
            if (Session["AuthenticatedUser"] == null)
            {
                deauthenticateUser();
                return false;
            }
            ViewBag.AuthenticatedUser = (DbUser)Session["AuthenticatedUser"];
            return true; 
        }

        private void authenticateUser(DbUser dbUser)
        {
            Session["AuthenticatedUser"] = dbUser;
            ViewBag.AuthenticatedUser = dbUser;
        }
        private void deauthenticateUser()
        {
            Session["AuthenticatedUser"] = null;
            ViewBag.AuthenticatedUser = null;
        }
    }
}
