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
    public class EditProductTests
    {
        private TechnoshopContext dbContext;
        private AdminProductService service;
        private string picLink = "https://example.com";

        [TestMethod]
        public async Task EditProduct_WithProperProduct_ShouldEditCorrect()
        {
            const string productName = "New Product Name";
            const string productSlug = "new-product-name";
            const double price = 20;
            const string description = "Some Description";


            const double priceEdited = 50;
            const string descriptionEdited = "Some Edited Description";
            const string picLinkEdited = "https://exampleEdit.com";

        var productModel = new ProductCreationBindingModel()
            {
                ModelName = productName,
                Slug = productSlug,
                Price = price,
                Description = description,
                ProductImageUrl = picLink
            };

            await this.service.CreateProductAsync(productModel);

            var editedProductModel = new ProductEditBindingModel()
            {
                Price = priceEdited,
                Description = descriptionEdited,
                ProductImageUrl = picLinkEdited
            };
            var product = this.dbContext.Products.First();

            await this.service.EditProductAsync(product.Id, editedProductModel);

            Assert.AreEqual(1, this.dbContext.Products.Count());
            Assert.AreEqual(priceEdited, product.Price);
            Assert.AreEqual(descriptionEdited, product.Description);
            Assert.AreEqual(picLinkEdited, product.ProductImageUrl);
        }

        [TestMethod]
        public async Task AddProduct_WithProductWithNullDescription_ShouldThrowException()
        {
            //Arrange

            const string productName = "New Product Name";
            const string productSlug = "new-product-name";
            const double price = 20;
            const string description = "Some Description";


            const double priceEdited = 50;
            const string descriptionEdited = null;
            const string picLinkEdited = "https://exampleEdit.com";

            var productModel = new ProductCreationBindingModel()
            {
                ModelName = productName,
                Slug = productSlug,
                Price = price,
                Description = description,
                ProductImageUrl = picLink
            };

            await this.service.CreateProductAsync(productModel);

            var editedProductModel = new ProductEditBindingModel()
            {
                Price = priceEdited,
                Description = descriptionEdited,
                ProductImageUrl = picLinkEdited
            };
            var product = this.dbContext.Products.First();
            //Act
            Func<Task> editProduct = () => this.service.EditProductAsync(product.Id, editedProductModel);

            //Assert
            var exception = await Assert.ThrowsExceptionAsync<ArgumentException>(editProduct);
            Assert.AreEqual(ValidationConstants.ProductDescriptionMessage, exception.Message);
        }

        [TestMethod]
        public async Task AddProduct_WithProductWithNegativePrice_ShouldThrowException()
        {
            //Arrange

            const string productName = "New Product Name";
            const string productSlug = "new-product-name";
            const double price = 20;
            const string description = "Some Description";


            const double priceEdited = -50;
            const string descriptionEdited = "Some Edited Description";
            const string picLinkEdited = "https://exampleEdit.com";

            var productModel = new ProductCreationBindingModel()
            {
                ModelName = productName,
                Slug = productSlug,
                Price = price,
                Description = description,
                ProductImageUrl = picLink
            };

            await this.service.CreateProductAsync(productModel);

            var editedProductModel = new ProductEditBindingModel()
            {
                Price = priceEdited,
                Description = descriptionEdited,
                ProductImageUrl = picLinkEdited
            };
            var product = this.dbContext.Products.First();
            //Act
            Func<Task> editProduct = () => this.service.EditProductAsync(product.Id, editedProductModel);

            //Assert
            var exception = await Assert.ThrowsExceptionAsync<ArgumentException>(editProduct);
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
