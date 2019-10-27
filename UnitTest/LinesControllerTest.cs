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
    public class LinesControllerTest
    {
        [TestMethod]
        public void Index()
        {
            var controller = new LinesController(new LineBLL(new LineRepositoryStab()));

            IStationRepository stationRepository = new StationRepositoryStab();
            var lines = new List<Line>();
            for (var i = 1; i <= 10; i++)
            {
                var line = new Line {LineId = i, Name = "Line " + i, LineStations = new List<LineStation>()};
                var num = 1;
                foreach (var station in stationRepository.Get())
                {
                    line.LineStations.Add(new LineStation
                    {
                        LineStationId = num++ * i,
                        Line = line,
                        Station = station,
                        Minutes = num * 10
                    });
                }
            }

            var actionResult = (ViewResult)controller.Index();
            var result = (List<Line>)actionResult.Model;

            Assert.AreEqual(actionResult.ViewName, "");
            for (var i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(lines[i].LineId, result[i].LineId);
                Assert.AreEqual(lines[i].Name, result[i].Name);
                for (var j = 0; j < lines[i].LineStations.Count; j++)
                {
                    Assert.AreEqual(lines[i].LineStations[j].Station.StationId, result[i].LineStations[j].Station.StationId);
                    Assert.AreEqual(lines[i].LineStations[j].Line.LineId, result[i].LineStations[j].Line.LineId);
                }
            }
        }

        [TestMethod]
        public void Delete()
        {
            var controller = new LinesController(new LineBLL(new LineRepositoryStab()));
            var actionResult = (RedirectToRouteResult)controller.Delete(3);
            Assert.IsNotNull(actionResult, "Not a redirect result");
            Assert.IsFalse(actionResult.Permanent);
            Assert.AreEqual("Index", actionResult.RouteValues["Action"]);
        }

        [TestMethod]
        public void Add()
        {
            var controller = new LinesController(new LineBLL(new LineRepositoryStab()));
            var line = new Line();
            var actionResult = (ViewResult)controller.Add();

            var result = (Line) actionResult.Model;

            Assert.AreEqual(actionResult.ViewName, "");
            Assert.AreEqual(result.LineId, line.LineId);
            Assert.AreEqual(result.Name, line.Name);
            Assert.AreEqual(result.LineStations, line.LineStations);
        }

        [TestMethod]
        public void Add_Line()
        {
            var controller = new LinesController(new LineBLL(new LineRepositoryStab()));
            var line = new Line {LineId = 1, LineStations = null, Name = "Test"};
            var actionResult = (RedirectToRouteResult)controller.Add(line);

            Assert.IsNotNull(actionResult, "Not a redirect result");
            Assert.IsFalse(actionResult.Permanent);
            Assert.AreEqual("Index", actionResult.RouteValues["Action"]);
        }

        [TestMethod]
        public void Edit()
        {
            var controller = new LinesController(new LineBLL(new LineRepositoryStab()));
            
            var actionResult = (ViewResult)controller.Edit(1);

            IStationRepository stationRepository = new StationRepositoryStab();

            var expectedResult = new Line {LineId = 1, Name = "Line " + 1, LineStations = new List<LineStation>()};
            var num = 1;
            foreach (var station in stationRepository.Get())
            {
                expectedResult.LineStations.Add(new LineStation
                {
                    LineStationId = num++ * 1,
                    Line = expectedResult,
                    Station = station,
                    Minutes = num * 10
                });
            }
            var result = (Line)actionResult.Model;

            Assert.AreEqual(actionResult.ViewName, "");
            Assert.AreEqual(result.LineId, expectedResult.LineId);
            Assert.AreEqual(result.Name, expectedResult.Name);
            for (var i = 0; i < expectedResult.LineStations.Count; i++)
            {
                Assert.AreEqual(expectedResult.LineStations[i].Station.StationId, result.LineStations[i].Station.StationId);
                Assert.AreEqual(expectedResult.LineStations[i].Line.LineId, result.LineStations[i].Line.LineId);
            }
        }

        [TestMethod]
        public void Edit_Line()
        {
            var controller = new LinesController(new LineBLL(new LineRepositoryStab()));
            var line = new Line { LineId = 1, LineStations = null, Name = "Test" };
            var actionResult = (RedirectToRouteResult)controller.Add(line);

            Assert.IsNotNull(actionResult, "Not a redirect result");
            Assert.IsFalse(actionResult.Permanent);
            Assert.AreEqual("Index", actionResult.RouteValues["Action"]);
        }
    }
}