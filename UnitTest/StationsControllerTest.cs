using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VyBillett.Controllers;

namespace UnitTest
{
    /// <summary>
    /// Unit test for StationsController
    /// </summary>
    [TestClass]
    public class StationsControllerTest
    {
        [TestMethod]
        public void Index()
        {
            var controller = new StationsController();
        }
    }
}
