using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Technoshop.Common.Buyer.ViewModels;
using Technoshop.Services.Admin.Interfaces;
using Technoshop.Web.Areas.Admin.Controllers;

namespace Technoshop.Tests.Controllers.Admin.CategoryControllerTests
{
    [TestClass]
    public class IndexTests
    {

        [TestMethod]
        public async Task Index_ReturnsAllCategories()
        {
            var categoryModel = new CategoryConciseViewModel() { Id = 1, Name = "First", CategoryPicUrl = "https://example.com" };
            bool methodCalled = false;
            //Arrange

            var mockRepository = new Mock<IAdminCategoryService>();
            mockRepository
                .Setup(service => service.GetCategoriesAsync())
                .ReturnsAsync(new[] { categoryModel })
                .Callback(() => methodCalled = true);

            var controller = new CategoriesController(mockRepository.Object);

            //Act
            var result = await controller.Index();

            //Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            var resultViewModel = result as ViewResult;
            Assert.IsNotNull(resultViewModel.Model);
            Assert.IsInstanceOfType(resultViewModel.Model, typeof(IEnumerable<CategoryConciseViewModel>));
            Assert.IsTrue(methodCalled);
        }

    }
}
