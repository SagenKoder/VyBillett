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
        private readonly IUserBLL _userBll;

        public AuthController(IUserBLL userBll, DbUser dbUser)
        {
            _userBll = userBll;
            SetSessionVariables(dbUser);
        }
        public AuthController()
        {
            _userBll = new UserBLL();
        }
        public ActionResult Index()
        {
            isAuthenticated();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(User user)
        {
            var dbUser = _userBll.AuthenticateAndGetUserIfOk(user.Username, user.Password);

            if (dbUser != null)
            {
                authenticateUser(dbUser);
                return RedirectToAction("Index", "Admin");
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
            
            var createdUser = _userBll.CreateNewUser(user.Username, user.Password);
            if (createdUser == null)
            {
                return View();
            }
            return RedirectToAction("Index", "Auth");
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

        private void SetSessionVariables(DbUser dbUser)
        {
            Session["AuthenticatedUser"] = dbUser;

        }
    }
}
