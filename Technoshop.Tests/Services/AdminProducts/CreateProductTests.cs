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

namespace Technoshop.Tests.Services.AdminProducts
{
    [TestClass]
    public class CreateProductTests
    {
        private TechnoshopContext dbContext;
        private AdminProductService service;
        private string picLink = "https://example.com";

        [TestMethod]
        public async Task CreateProduct_WithProperProduct_ShouldAddCorrectly()
        {


            const string productName = "New Product Name";
            const string productSlug = "new-product-name";
            const double price = 20;
            const string description = "Some Description";


            var productModel = new ProductCreationBindingModel()
            {
                ModelName = productName,
                Slug = productSlug,
                Price = price,
                Description = description,
                ProductImageUrl = picLink
            };

            //Act
            await this.service.CreateProductAsync(productModel);

            //Assert
            var product = this.dbContext.Products.First();
            Assert.AreEqual(1, this.dbContext.Products.Count());
            Assert.AreEqual(productName, product.ModelName);
            Assert.AreEqual(productSlug, product.Slug);
            Assert.AreEqual(price, product.Price);
            Assert.AreEqual(description, product.Description);
            Assert.AreEqual(picLink, product.ProductImageUrl);
        }

        [TestMethod]
        public async Task AddProduct_WithNullProduct_ShouldThrowException()
        {
            //Arrange

            ProductCreationBindingModel productModel = null;

            //Act
            Func<Task> addProduct = () => this.service.CreateProductAsync(productModel);

            //Assert
            var exception = await Assert.ThrowsExceptionAsync<ArgumentException>(addProduct);
            Assert.AreEqual(ValidationConstants.ProductIsDefinedMessage, exception.Message);
        }

        [TestMethod]
        public async Task AddProduct_WithProductWithNullName_ShouldThrowException()
        {
            //Arrange

            ProductCreationBindingModel productModel  = new ProductCreationBindingModel()
            {
                ModelName = null,
                Slug = "null",
                Price = 20,
                Description = "null",
                ProductImageUrl = picLink
            };

            //Act
            Func<Task> addProduct = () => this.service.CreateProductAsync(productModel);

            //Assert
            var exception = await Assert.ThrowsExceptionAsync<ArgumentException>(addProduct);
            Assert.AreEqual(ValidationConstants.ProductNameMessage, exception.Message);
        }

        [TestMethod]
        public async Task AddProduct_WithProductWithNegativePrice_ShouldThrowException()
        {
            //Arrange

            ProductCreationBindingModel productModel = new ProductCreationBindingModel()
            {
                ModelName = "Null",
                Slug = "null",
                Price = -20,
                Description = "null",
                ProductImageUrl = picLink
            };

            //Act
            Func<Task> addProduct = () => this.service.CreateProductAsync(productModel);

            //Assert
            var exception = await Assert.ThrowsExceptionAsync<ArgumentException>(addProduct);
            Assert.AreEqual(ValidationConstants.ProductPriceMessage, exception.Message);
        }

        [TestInitialize]
        public void InitializeTests()
        {
            this.dbContext = MockDbContext.GetContext();
            this.service = new AdminProductService(this.dbContext, MockAutoMapper.GetMapper());
        }

    }


}

