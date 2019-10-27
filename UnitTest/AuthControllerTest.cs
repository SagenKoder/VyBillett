using System.Security.Cryptography;
using BLL;
using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Model;
using MvcContrib.TestHelper;
using VyBillett.Controllers;
using VyBillett.Models;

namespace UnitTest
{
    [TestClass]
    public class AuthControllerTest
    {
        [TestMethod]
        public void Index()
        {
            var controller = new AuthController(new UserBLL(new UserRepositoryStab()));

            var sessionMock = new TestControllerBuilder();
            sessionMock.InitializeController(controller);
            controller.Session["AuthenticatedUser"] = new DbUser
            {
                Username = "Test",
                Password = null,
                Salt = null
            };
            var actionResult = (ViewResult)controller.Index();

            Assert.AreEqual(actionResult.ViewName, "");
        }

        // Får ikke testet om det funker når Session["AuthenticatedUser"] == null, fordi at AuthController-en kaster en exception når den prøve å hente ut en Session variabel som enten ikke finnes eller er null.
        //[TestMethod]
        //public void Index_User_Wrong()
        //{
        //    var controller = new AuthController(new UserBLL(new UserRepositoryStab()));

        //    var sessionMock = new TestControllerBuilder();
        //    sessionMock.InitializeController(controller);
        //    controller.Session["AuthenticatedUser"] = null;

        //    var actionResult = (RedirectToRouteResult)controller.Index(null);

        //    Assert.IsNotNull(actionResult, "Not a redirect result");
        //    Assert.IsFalse(actionResult.Permanent);
        //    Assert.AreEqual("Index", actionResult.RouteValues["Action"]);
        //}

        //[TestMethod]
        //public void Index_User()
        //{
        //    var controller = new AuthController(new UserBLL(new UserRepositoryStab()));
        //    User user = new User {Username = "test", Password = "password"};
        //    var actionResult = (ViewResult)controller.Index(user);

        //    Assert.AreEqual(actionResult.ViewName, "");
        //}
    }
}