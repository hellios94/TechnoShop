using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technoshop.Data;
using Technoshop.Models;
using Technoshop.Services.Admin;
using Technoshop.Tests.Mocks;
using Technoshop.Web.Mapper;

namespace Technoshop.Tests.Services.AdminCategories
{
    [TestClass]
    public class ModeratorGetCategoriesTests
    {
        private TechnoshopContext dbContext;
        private AdminCategoryService service;
        private string picLink = "https://example.com";

        [TestMethod]
        public async Task GetCategoryAsync_WithAFewCategories_ShouldReturnAll()
        { 

            //Arrange
            
            this.dbContext.Categories.Add(new Category() { Id = 1, Name = "First Category", CategoryPicUrl = this.picLink });
            this.dbContext.Categories.Add(new Category() { Id = 2, Name = "Second Category", CategoryPicUrl = this.picLink });
            this.dbContext.Categories.Add(new Category() { Id = 3, Name = "Third Category", CategoryPicUrl = this.picLink });

            this.dbContext.SaveChanges();

            //Act
            var categories = await service.GetCategoriesAsync();

            //Assert
            Assert.IsNotNull(categories);
            Assert.AreEqual(3, categories.Count());
            CollectionAssert.AreEqual(new[] { 1, 2, 3 }, categories.Select(c => c.Id).ToArray());
        }

        [TestMethod]
        public async Task GetCategoryAsync_WithNoCategories_ShouldReturnNone()
        {

            //Arrange


            //Act
            var categories = await this.service.GetCategoriesAsync();

            //Assert
            Assert.IsNotNull(categories);
            Assert.AreEqual(0, categories.Count());
        }


        [TestInitialize]
        public void InitializeTests ()
        {
            this.dbContext = MockDbContext.GetContext();
            this.service = new AdminCategoryService(dbContext, MockAutoMapper.GetMapper());
        }
    }
}
