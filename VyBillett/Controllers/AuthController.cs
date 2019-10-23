using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using VyBillett.Models;

namespace VyBillett.Controllers
{
    public class AuthController : Controller
    {
        public ActionResult Index()
        {
            // vis innlogging
            if (Session["Authenticated"] == null)
            {
                Session["Authenticated"] = false;
                ViewBag.Authenticated = false;
            }
            else
            {
                ViewBag.Authenticated = (bool)Session["Authenticated"];
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(User authenticatedUser)
        {
            // sjekk om innlogging OK
            if (userInDb(authenticatedUser))
            {
                // ja brukernavn og passord er OK!
                Session["Authenticated"] = true;
                ViewBag.Authenticated = true;
                return View();
            }
            else
            {
                // ja brukernavn og passord er OK!
                Session["Authenticated"] = false;
                ViewBag.Authenticated = false;
                return View();
            }
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User authenticatedUser)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            using (var db = new VyDbContext())
            {
                try
                {
                    var createdUser = new DbUser();
                    byte[] salt = createSalt();
                    byte[] hash = createHash(authenticatedUser.Password, salt);
                    createdUser.Navn = authenticatedUser.Username;
                    createdUser.Passord = hash;
                    createdUser.Salt = salt;
                    db.DbUsers.Add(createdUser);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception feil)
                {
                    return View();
                }
            }
        }

        private static byte[] createHash(string password, byte[] salt)
        {
            const int keyLength = 24;
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 1000); // 1000 angir hvor mange ganger hash funskjonen skal utføres for økt sikkerhet
            return pbkdf2.GetBytes(keyLength);
        }

        private static byte[] createSalt()
        {
            var csprng = new RNGCryptoServiceProvider();
            var salt = new byte[24];
            csprng.GetBytes(salt);
            return salt;
        }

        private static bool userInDb(User user)
        {
            using (var db = new VyDbContext())
            {
                DbUser dbUser = db.DbUsers.FirstOrDefault(b => b.Navn == user.Username);
                if (dbUser != null)
                {
                    byte[] testPassword = createHash(user.Password, dbUser.Salt);
                    bool correctPassword = dbUser.Passord.SequenceEqual(testPassword);  // merk denne testen!
                    return correctPassword;
                }
                else
                {
                    return false;
                }
            }
        }

        public ActionResult Logout()
        {
            Session["Authenticated"] = false;
            return RedirectToAction("Index", "Auth");
        }
    }
}
