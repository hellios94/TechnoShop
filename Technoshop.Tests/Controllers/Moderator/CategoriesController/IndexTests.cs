using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Technoshop.Common.Buyer.ViewModels;
using Technoshop.Services.Moderator.Interfaces;
using Technoshop.Web.Areas.Moderator.Controllers;

namespace Technoshop.Tests.Controllers.Moderator.CategoriesControllerTests
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

            var mockRepository = new Mock<IModeratorCategoryService>();
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
