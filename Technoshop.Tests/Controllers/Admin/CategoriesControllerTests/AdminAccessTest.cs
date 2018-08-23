using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Technoshop.Web.Areas.Admin.Controllers;
using Technoshop.Web.Constants;

namespace Technoshop.Tests.Controllers.Admin.CategoriesControllerTests
{
    [TestClass]
    public class AdminAccessTest
    {

        [TestMethod]
        public void CategoriesController_ShouldBeInAdminArea()
        {

            //Arrange
            var controller = new CategoriesController(null);
            var area = typeof(CategoriesController).GetCustomAttributes(true)
                .FirstOrDefault(atr => atr is AreaAttribute) as AreaAttribute;

            //Assert
            Assert.IsNotNull(area);
            Assert.AreEqual(WebConstants.AdminArea, area.RouteValue);
        }

        [TestMethod]
        public void CategoriesController_ShouldAuthorizeAdmins()
        {

            //Arrange
            var autharization = typeof(CategoriesController).GetCustomAttributes(true)
                .FirstOrDefault(atr => atr is AuthorizeAttribute) as AuthorizeAttribute;

            //Assert
            Assert.IsNotNull(autharization);
            Assert.AreEqual(WebConstants.AdminRole, autharization.Roles);
        }

    }
}
