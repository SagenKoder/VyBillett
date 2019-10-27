using System;
using System.Text;
using System.Collections.Generic;
using System.Web.Mvc;
using BLL;
using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using VyBillett.Controllers;

namespace UnitTest
{
    [TestClass]
    public class StationsControllerTest
    {
        [TestMethod]
        public void Index()
        {
            var controller = new StationsController(new StationBLL(new StationRepositoryStab()));

            var stations = new List<Station>();
            var oslos = new Station { StationId = 0, Name = "Oslo S", LineStations = null };

            stations.Add(oslos);
            stations.Add(oslos);
            stations.Add(oslos);

            var actionResult = (ViewResult) controller.Index();
            var result = (List<Station>) actionResult.Model;

            Assert.AreEqual(actionResult.ViewName, "");

            for (var i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(stations[i].StationId, result[i].StationId);
                Assert.AreEqual(stations[i].Name, result[i].Name);
                Assert.AreEqual(stations[i].LineStations, result[i].LineStations);
            }
        }

        [TestMethod]
        public void Delete()
        {
            var controller = new StationsController(new StationBLL(new StationRepositoryStab()));
            var actionResult = (RedirectToRouteResult)controller.Delete(3);
            Assert.IsNotNull(actionResult, "Not a redirect result");
            Assert.IsFalse(actionResult.Permanent);
            Assert.AreEqual("Index", actionResult.RouteValues["Action"]);
        }
        [TestMethod]
        public void Edit()
        {
            var controller = new StationsController(new StationBLL(new StationRepositoryStab()));
            var result = (ViewResult)controller.Edit(5);
            Assert.AreEqual("", result.ViewName);
            var station = (Station)result.Model; 
            Assert.AreEqual(0, station.StationId);
        }
        [TestMethod]
        public void Edit_Post()
        {
            var station = new Station { StationId = 1, Name = "Oslo S", LineStations = null };

            var controller = new StationsController(new StationBLL(new StationRepositoryStab()));
            var actionResult = (RedirectToRouteResult) controller.Edit(station);

            Assert.IsNotNull(actionResult, "Not a redirect result");
            Assert.IsFalse(actionResult.Permanent);
            Assert.AreEqual("Index", actionResult.RouteValues["Action"]);
        }
        [TestMethod]
        public void Add()
        {
            var station = new Station { StationId = 1, Name = "Oslo S", LineStations = null };

            var controller = new StationsController(new StationBLL(new StationRepositoryStab()));
            var actionResult = (ViewResult)controller.Add();
            Assert.AreEqual("", actionResult.ViewName);
            var stationRet = (Station)actionResult.Model;
            Assert.AreEqual(1, station.StationId);
        }
        [TestMethod]
        public void Add_Post()
        {
            var station = new Station { StationId = 1, Name = "Oslo S", LineStations = null };

            var controller = new StationsController(new StationBLL(new StationRepositoryStab()));
            var actionResult = (RedirectToRouteResult)controller.Add(station);
            Assert.IsNotNull(actionResult, "Not a redirect result");
            Assert.IsFalse(actionResult.Permanent);
            Assert.AreEqual("Index", actionResult.RouteValues["Action"]);
        }
    }
}
