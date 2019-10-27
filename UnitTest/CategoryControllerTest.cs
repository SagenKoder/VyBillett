using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BLL;
using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using VyBillett.Controllers;

namespace UnitTest
{
    [TestClass]
    public class CategoryControllerTest
    {
        [TestMethod]
        public void Index()
        {
            var controller = new CategoryController(new CategoryBLL(new CategoryRepositoryStab()));
            var categories = new List<Category>();

            var Adult = new Category { CategoryPrice = 120, CategoryName = "Adult" };
            var Student = new Category { CategoryPrice = 95, CategoryName = "Student" };
            var Child = new Category { CategoryPrice = 60, CategoryName = "Child" };

            categories.Add(Adult);
            categories.Add(Student);
            categories.Add(Child);

            var actionResult = (ViewResult)controller.Index();
            var result = (List<Category>)actionResult.Model;

            Assert.AreEqual(actionResult.ViewName, "");

            for (var i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(categories[i].CategoryId, result[i].CategoryId);
                Assert.AreEqual(categories[i].CategoryName, result[i].CategoryName);
                Assert.AreEqual(categories[i].CategoryPrice, result[i].CategoryPrice);
            }
        }

        [TestMethod]
        public void Edit_Id()
        {
            var controller = new CategoryController(new CategoryBLL(new CategoryRepositoryStab()));
            var actionResult = (ViewResult)controller.Edit(1);
            var result = (Category)actionResult.Model;

            var expectedResult = new Category { CategoryId = 1, CategoryPrice = 120, CategoryName = "Adult" };
            
            Assert.AreEqual(actionResult.ViewName, "");
            Assert.AreEqual(result.CategoryId, expectedResult.CategoryId);
            Assert.AreEqual(result.CategoryName, expectedResult.CategoryName);
            Assert.AreEqual(result.CategoryPrice, expectedResult.CategoryPrice);
        }

        [TestMethod]
        public void Edit_Category()
        {
            var controller = new CategoryController(new CategoryBLL(new CategoryRepositoryStab()));
            var category = new Category { CategoryId = 1, CategoryPrice = 120, CategoryName = "Adult" };

            var resultat = (RedirectToRouteResult)controller.Edit(category);

            // Assert
            Assert.AreEqual(resultat.RouteName, "");
            Assert.AreEqual((string) resultat.RouteValues.Values.First(), "Index");
        }
    }
}
