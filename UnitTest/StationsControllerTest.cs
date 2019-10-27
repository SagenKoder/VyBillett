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

            Assert.AreEqual(actionResult.ViewName, "Index");

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
            Assert.NotNull(result, "Not a redirect result");
            Assert.IsFalse(result.Permanent);
            Assert.AreEqual("Index", result.RouteValues["Action"]);
            Assert.AreEqual("Stations", result.RouteValues["Controller"]);
        }

        public void Edit()
        {
            var controller = new StationsController(new StationBLL(new StationRepositoryStab()));
            var result = controller.Edit(5);
            Assert.AreEqual(actionResult.ViewName, "Edit");
        }

        public void Edit_Post()
        {
            var controller = new StationsController(new StationBLL(new StationRepositoryStab()));

        }

        public void Add()
        {
            var controller = new StationsController(new StationBLL(new StationRepositoryStab()));

        }

        public void Add_Post()
        {
            var controller = new StationsController(new StationBLL(new StationRepositoryStab()));

        }
    }
}
