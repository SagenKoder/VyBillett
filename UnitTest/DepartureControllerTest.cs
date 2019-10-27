using BLL;
using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using MvcContrib.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VyBillett.Controllers;

namespace UnitTest
{
    [TestClass]
    public class DepartureControllerTest : Controller
    {
        [TestMethod]
        public void Index()
        {
            var controller = new DepartureController(
                new DepartureBLL(new DepartureRepositoryStab()),
                new LineBLL(new LineRepositoryStab())
            );

            var sessionMock = new TestControllerBuilder();
            sessionMock.InitializeController(controller);
            controller.Session["AuthenticatedUser"] = new DbUser
            {
                Username = "Test",
                Password = null,
                Salt = null
            };
            var actionResult = (ViewResult)controller.Index(4);
            var data = (List<Departure>)actionResult.Model;

            Assert.AreEqual("", actionResult.ViewName);
            Assert.IsNotNull(data);
            Assert.AreEqual(0, data.Count());
        }
        [TestMethod]
        public void Add()
        {
            var controller = new DepartureController(
                new DepartureBLL(new DepartureRepositoryStab()),
                new LineBLL(new LineRepositoryStab())
            );

            var sessionMock = new TestControllerBuilder();
            sessionMock.InitializeController(controller);
            controller.Session["AuthenticatedUser"] = new DbUser
            {
                Username = "Test",
                Password = null,
                Salt = null
            };
            var actionResult = (ViewResult)controller.Add(4);
            var data = (Departure)actionResult.Model;

            Assert.AreEqual("", actionResult.ViewName);
            Assert.IsNotNull(data);
            Assert.IsNotNull(data.Line);
        }
        [TestMethod]
        public void Add_post()
        {
            var departure = new Departure
            {
                DepartureId = 4
            };

            var controller = new DepartureController(
                new DepartureBLL(new DepartureRepositoryStab()),
                new LineBLL(new LineRepositoryStab())
            );

            var sessionMock = new TestControllerBuilder();
            sessionMock.InitializeController(controller);
            controller.Session["AuthenticatedUser"] = new DbUser
            {
                Username = "Test",
                Password = null,
                Salt = null
            };
            var actionResult = (RedirectToRouteResult)controller.Add(departure, 4);

            Assert.IsNotNull(actionResult, "Not a redirect result");
            Assert.IsFalse(actionResult.Permanent);
            Assert.AreEqual("Index", actionResult.RouteValues["Action"]);
            Assert.AreEqual(2, actionResult.RouteValues.Count());
        }
        [TestMethod]
        public void Delete()
        {
            var controller = new DepartureController(
                new DepartureBLL(new DepartureRepositoryStab()),
                new LineBLL(new LineRepositoryStab())
            );

            var actionResult = (RedirectToRouteResult)controller.Delete(3);
            Assert.IsNotNull(actionResult, "Not a redirect result");
            Assert.IsFalse(actionResult.Permanent);
            Assert.AreEqual("Index", actionResult.RouteValues["Action"]);
            Assert.AreEqual(2, actionResult.RouteValues.Count());
        }

    }
}