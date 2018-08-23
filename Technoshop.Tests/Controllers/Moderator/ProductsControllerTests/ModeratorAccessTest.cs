using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Technoshop.Web.Areas.Moderator.Controllers;
using Technoshop.Web.Constants;

namespace Technoshop.Tests.Controllers.Moderator.ProductsControllerTests
{
    [TestClass]
    public class ModeratorAccessTest
    {

        [TestMethod]
        public void ProductsController_ShouldBeInAdminArea()
        {

            //Arrange
            var controller = new ProductsController(null, null);
            var area = typeof(ProductsController).GetCustomAttributes(true)
                .FirstOrDefault(atr => atr is AreaAttribute) as AreaAttribute;

            //Assert
            Assert.IsNotNull(area);
            Assert.AreEqual(WebConstants.ModeratorArea, area.RouteValue);
        }

        [TestMethod]
        public void ProductsController_ShouldAuthorizeAdmins()
        {

            //Arrange
            var autharization = typeof(ProductsController).GetCustomAttributes(true)
                .FirstOrDefault(atr => atr is AuthorizeAttribute) as AuthorizeAttribute;

            //Assert
            Assert.IsNotNull(autharization);
            Assert.AreEqual(WebConstants.ModeratorAreaRoles, autharization.Roles);
        }

    }
}
