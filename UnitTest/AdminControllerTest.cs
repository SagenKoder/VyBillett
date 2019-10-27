using BLL;
using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using MvcContrib.TestHelper;
using System.Web.Mvc;
using VyBillett.Controllers;
using VyBillett.Models;

namespace UnitTest
{
    [TestClass]
    public class AdminControllerTest
    {
        [TestMethod]
        public void Index()
        {
            var controller = new AdminController(
                new UserBLL(new UserRepositoryStab()),
                new StationBLL(new StationRepositoryStab()),
                new LineBLL(new LineRepositoryStab()),
                new DepartureBLL(new DepartureRepositoryStab()),
                new TicketBLL(new TicketRepositoryStab())
            );

            var sessionMock = new TestControllerBuilder();
            sessionMock.InitializeController(controller);
            controller.Session["AuthenticatedUser"] = new DbUser
            {
                Username = "Test",
                Password = null,
                Salt = null
            };
            var actionResult = (ViewResult)controller.Index();
            var statisticsDTO = (StatisticsDTO)actionResult.Model;

            Assert.AreEqual("", actionResult.ViewName);
            Assert.AreEqual(10, statisticsDTO.NumDepartures);
            Assert.AreEqual(10, statisticsDTO.NumLines);
            Assert.AreEqual(3, statisticsDTO.NumStations);
            Assert.AreEqual(5, statisticsDTO.NumTickets);
            Assert.AreEqual(3, statisticsDTO.NumUsers);
        }
    }
}
