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
        public ActionResult Index(User innLogget)
        {
            // sjekk om innlogging OK
            if (bruker_i_db(innLogget))
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
        public ActionResult Registrer()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registrer(User innBruker)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            using (var db = new VyDbContext())
            {
                try
                {
                    var nyBruker = new DbUser();
                    byte[] salt = lagSalt();
                    byte[] hash = lagHash(innBruker.Password, salt);
                    nyBruker.Navn = innBruker.Username;
                    nyBruker.Passord = hash;
                    nyBruker.Salt = salt;
                    db.DbUsers.Add(nyBruker);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception feil)
                {
                    return View();
                }
            }
        }
        private static byte[] lagHash(string innPassord, byte[] innSalt)
        {
            const int keyLength = 24;
            var pbkdf2 = new Rfc2898DeriveBytes(innPassord, innSalt, 1000); // 1000 angir hvor mange ganger hash funskjonen skal utføres for økt sikkerhet
            return pbkdf2.GetBytes(keyLength);
        }

        private static byte[] lagSalt()
        {
            var csprng = new RNGCryptoServiceProvider();
            var salt = new byte[24];
            csprng.GetBytes(salt);
            return salt;
        }

        private static bool bruker_i_db(User innBruker)
        {
            using (var db = new VyDbContext())
            {
                DbUser funnetBruker = db.DbUsers.FirstOrDefault(b => b.Navn == innBruker.Username);
                if (funnetBruker != null)
                {
                    byte[] passordForTest = lagHash(innBruker.Password, funnetBruker.Salt);
                    bool riktigBruker = funnetBruker.Passord.SequenceEqual(passordForTest);  // merk denne testen!
                    return riktigBruker;
                }
                else
                {
                    return false;
                }
            }
        }
        public ActionResult InnloggetSide()
        {
            if (Session["Authenticated"] == null || !((bool) Session["Authenticated"]))
            {
                return RedirectToAction("Index", "Auth");
            }

            return View();
        }

        public ActionResult LoggUt()
        {
            Session["Authenticated"] = false;
            return RedirectToAction("index");
        }

        public ActionResult DecryptHash()
        {
            return View();
        }
    }
}
