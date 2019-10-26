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
        private CategoryBLL categoryBLL = new CategoryBLL();
        // GET: Category
        public ActionResult Index()
        {
            var categories = categoryBLL.Get();
            return View(categories);
        }

        public ActionResult Edit(int id)
        {
            Category category = categoryBLL.Get(id);
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            categoryBLL.Edit(category.CategoryId, category);
            return RedirectToAction("Index");
        }
    }
}