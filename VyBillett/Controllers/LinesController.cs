using BLL;
using DAL;
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
    }
}