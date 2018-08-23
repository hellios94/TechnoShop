using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Technoshop.Common.Admin.BindingModels;
using Technoshop.Services.Admin.Interfaces;
using Technoshop.Web.Areas.Admin.Controllers;

namespace Technoshop.Tests.Controllers.Admin.CategoryControllerTests
{
    [TestClass]
    public class CreateTests
    {
        [TestMethod]
        public void Create_WithValidCategory_ShouldReturnView()
        {
            //Arrange
            bool serviceCalled = false;

            var mockRepository = new Mock<IAdminCategoryService>();
            mockRepository
                .Setup(service => service.AddCategoryAsync(It.IsAny<CategoryCreationBindingModel>()))
                .Callback(() => serviceCalled = true);

            var controller = new CategoriesController(mockRepository.Object);
            //Act
            var result = controller.Create(new CategoryCreationBindingModel());

            //Assert
            Assert.IsTrue(serviceCalled);
        }

    }
}
