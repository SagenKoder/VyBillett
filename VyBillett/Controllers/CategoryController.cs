using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VyBillett.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryBLL _categoryBll;

        public CategoryController(ICategoryBLL categoryBll)
        {
            _categoryBll = categoryBll;
        }

        public CategoryController()
        {
            _categoryBll = new CategoryBLL();
        }

        // GET: Category
        public ActionResult Index()
        {
            if (!isAuthenticated())
            {
                return RedirectToAction("Index", "Auth");
            }
            var categories = _categoryBll.Get();
            return View(categories);
        }

        public ActionResult Edit(int id)
        {
            if (!isAuthenticated())
            {
                return RedirectToAction("Index", "Auth");
            }
            Category category = _categoryBll.Get(id);
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (!isAuthenticated())
            {
                return RedirectToAction("Index", "Auth");
            }
            _categoryBll.Edit(category.CategoryId, category);
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