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
            var categories = _categoryBll.Get();
            return View(categories);
        }

        public ActionResult Edit(int id)
        {
            Category category = _categoryBll.Get(id);
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            _categoryBll.Edit(category.CategoryId, category);
            return RedirectToAction("Index");
        }
    }
}