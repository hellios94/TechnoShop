using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Technoshop.Common.Admin.BindingModels;
using Technoshop.Services.Admin.Interfaces;
using Technoshop.Web.Areas.Admin.Controllers;

namespace Technoshop.Tests.Controllers.Admin.ProductControllerTests
{
    [TestClass]
    public class CreateTests
    {
        [TestMethod]
        public void Create_WithValidProduct_ShouldReturnView()
        {
            //Arrange
            bool serviceCalled = false;

            var mockRepository = new Mock<IAdminCategoryService>();

            var mockRepositoryProduct = new Mock<IAdminProductService>();
            mockRepositoryProduct
                .Setup(service => service.CreateProductAsync(It.IsAny<ProductCreationBindingModel>()))
                .Callback(() => serviceCalled = true);

            var controller = new ProductsController(mockRepositoryProduct.Object, mockRepository.Object);
            //Act
            var result = controller.Create(new ProductCreationBindingModel());

            //Assert
            Assert.IsTrue(serviceCalled);
        }

    }
}
