using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VyBillett.Models;

namespace VyBillett.Controllers
{
    public class HomeController : Controller
    {
        private Db db = new Db();

        protected override void Dispose(bool disposing)
        {
            // Denne vil dispose dbContext etter view´et er rendret ferdig!
            // Slik kan vi aksessere alleKundene via lazy loading der.
            // Dette har ikke noe med ToList() å gjøre.
            // Ved bruk av Using vil vi noen ganger få problemer med dette.
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Index()
        {
            ViewData["stations"] = db.Stations.ToList();
            return View(new TicketDTO());
        }

        [HttpPost]
        public ActionResult Index(TicketDTO ticket)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View(ticket);
        }

        public ActionResult FindDepartures()
        {
            using (var db = new Models.Db())
            {

            }
            return View();
        }
    }
}