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
        private LineBLL lineBLL = new LineBLL();
        // GET: Lines
        public ActionResult Index()
        {

            var lines = lineBLL.GetAllLines();
            return View(lines);
        }

        public ActionResult Delete(int id)
        {
            lineBLL.DeleteLine(id);
            return RedirectToAction("Index");
        }

        public ActionResult Add()
        {

            return View(new Line());
        }

        [HttpPost]
        public ActionResult Add(Line line)
        {
            System.Diagnostics.Debug.WriteLine("LinesController Add Line (Name): " + line.Name);
            lineBLL.Insert(line);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Line line = lineBLL.GetLineFromId(id);
            return View(line);
        }

        [HttpPost]
        public ActionResult Edit(Line line)
        {
            lineBLL.EditLine(line.LineId, line);
            return RedirectToAction("Index");
        }

       
    }
}