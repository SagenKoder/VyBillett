using BLL;
using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Model;
using VyBillett.Controllers;

namespace UnitTest
{
    [TestClass]
    public class AuthControllerTest
    {
        //[TestMethod]
        //public void Index()
        //{
        //    var dbUser = new DbUser();
        //    dbUser.Username = "username";
        //    dbUser.Password = null;
        //    dbUser.Salt = null;
        //    var controller = new AuthController(new UserBLL(new UserRepositoryStab()), dbUser);
        //    var actionResult = (ViewResult)controller.Index();

        //    Assert.AreEqual(actionResult.ViewName, "");
        //}

        //[TestMethod]
        //public void Index_User_Wrong()
        //{
        //    var controller = new AuthController(new UserBLL(new UserRepositoryStab()));

        //    var actionResult = (RedirectToRouteResult)controller.Index(null);

        //    Assert.IsNotNull(actionResult, "Not a redirect result");
        //    Assert.IsFalse(actionResult.Permanent);
        //    Assert.AreEqual("Index", actionResult.RouteValues["Action"]);
        //}
    }
}