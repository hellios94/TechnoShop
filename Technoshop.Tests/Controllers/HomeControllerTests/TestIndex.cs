using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Technoshop.Web.Controllers;

namespace Technoshop.Tests.Controllers.HomeControllerTests
{
    [TestClass]
    public class TestIndex
    {

        [TestMethod]
        public void Index_Returns_TheProperView()
        {
            var controller = new HomeController();

            var result = controller.Index();

            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

    }
}
