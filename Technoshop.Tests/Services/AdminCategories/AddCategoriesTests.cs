using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technoshop.Common.Admin.BindingModels;
using Technoshop.Common.Validation;
using Technoshop.Data;
using Technoshop.Services.Admin;
using Technoshop.Tests.Mocks;

namespace Technoshop.Tests.Services.AdminCategories
{
    [TestClass]
    public class AddCategoriesTests
    {
        private TechnoshopContext dbContext;
        private AdminCategoryService service;
        private string picLink = "https://example.com";

        [TestMethod]
        public async Task AddCategories_WithProperCategory_ShouldAddCorrectly()
        {
            //Arrange
            const string categoryName = "New Category Name";
            const string categorySlug = "new-category-name";
            var categoryModel = new CategoryCreationBindingModel()
            {
                Name = categoryName,
                Slug = categorySlug,
                CategoryPicUrl = picLink
            };

            //Act
                await this.service.AddCategoryAsync(categoryModel);

            //Assert
            var category = this.dbContext.Categories.First();
            Assert.AreEqual(1, this.dbContext.Categories.Count());
            Assert.AreEqual(categoryName, category.Name);
            Assert.AreEqual(categorySlug, category.Slug);
            Assert.AreEqual(picLink, category.CategoryPicUrl);
        }

        [TestMethod]
        public async Task AddCategories_WithNullCategory_ShouldThrowException()
        {
            //Arrange

            CategoryCreationBindingModel categoryModel = null;

            //Act
             Func<Task> addCourse = () => this.service.AddCategoryAsync(categoryModel);

            //Assert
            var exception = await Assert.ThrowsExceptionAsync<ArgumentException>(addCourse);
            Assert.AreEqual(ValidationConstants.CategoryIsDefinedMessage, exception.Message);
        }

        [TestMethod]
        public async Task AddCategories_WithCategoryWithNullName_ShouldThrowException()
        {
            //Arrange

            CategoryCreationBindingModel categoryModel = new CategoryCreationBindingModel()
            {
                Name = null,
                Slug = "null",
                CategoryPicUrl = picLink
            };

            //Act
            Func<Task> addCourse = () => this.service.AddCategoryAsync(categoryModel);

            //Assert
            var exception = await Assert.ThrowsExceptionAsync<ArgumentException>(addCourse);
            Assert.AreEqual(ValidationConstants.CategoryNameMessage, exception.Message);
        }

        [TestInitialize]
        public void InitializeTests()
        {
            this.dbContext = MockDbContext.GetContext();
            this.service = new AdminCategoryService(dbContext, MockAutoMapper.GetMapper());
        }
    }
}
