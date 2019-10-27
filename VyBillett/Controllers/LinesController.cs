using BLL;
using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VyBillett.Controllers
{
    public class LinesController : Controller
    {
        private readonly ILineBLL _lineBll;

        public LinesController(ILineBLL lineBll)
        {
            _lineBll = lineBll;
        }

        public LinesController()
        {
            _lineBll = new LineBLL();
        }
        // GET: Lines
        public ActionResult Index()
        {
            if (!isAuthenticated())
            {
                return RedirectToAction("Index", "Auth");
            }
            var lines = _lineBll.GetAllLines();
            return View(lines);
        }

        public ActionResult Delete(int id)
        {
            if (!isAuthenticated())
            {
                return RedirectToAction("Index", "Auth");
            }
            _lineBll.DeleteLine(id);
            return RedirectToAction("Index");
        }

        public ActionResult Add()
        {
            if (!isAuthenticated())
            {
                return RedirectToAction("Index", "Auth");
            }
            return View(new Line());
        }

        [HttpPost]
        public ActionResult Add(Line line)
        {
            if (!isAuthenticated())
            {
                return RedirectToAction("Index", "Auth");
            }
            System.Diagnostics.Debug.WriteLine("LinesController Add Line (Name): " + line.Name);
            _lineBll.Insert(line);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            if (!isAuthenticated())
            {
                return RedirectToAction("Index", "Auth");
            }
            Line line = _lineBll.GetLineFromId(id);
            return View(line);
        }

        [HttpPost]
        public ActionResult Edit(Line line)
        {
            if (!isAuthenticated())
            {
                return RedirectToAction("Index", "Auth");
            }
            _lineBll.EditLine(line.LineId, line);
            return RedirectToAction("Index");
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


    }
}