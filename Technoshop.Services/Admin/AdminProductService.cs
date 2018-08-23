using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Technoshop.Common.Admin.BindingModels;
using Technoshop.Common.Admin.ViewModels;
using Technoshop.Common.Buyer.ViewModels;
using Technoshop.Common.Validation;
using Technoshop.Data;
using Technoshop.Models;
using Technoshop.Services.Admin.Interfaces;
using Technoshop.Services.Exceptions;

namespace Technoshop.Services.Admin
{
    public class AdminProductService : BaseEFService, IAdminProductService
    {
        public AdminProductService(TechnoshopContext dbContext,
            IMapper mapper)
            :base(dbContext, mapper)
        {
        }

        public async Task<int> CreateProductAsync(ProductCreationBindingModel model)
        {
            Validator.EnsureNotNull(model, ValidationConstants.ProductIsDefinedMessage);
            Validator.EnsureStringIsNotNullOrEmpty(model.ModelName, ValidationConstants.ProductNameMessage);
            Validator.EnsureStringIsNotNullOrEmpty(model.Slug, ValidationConstants.ProductSlugMessage);
            Validator.EnsureStringIsNotNullOrEmpty(model.Description, ValidationConstants.ProductDescriptionMessage);
            Validator.EnsureDoubleIsNotNegativeOrZero(model.Price, ValidationConstants.ProductPriceMessage);

            var product = this.Mapper.Map<Product>(model);
            await this.DbContext.Products.AddAsync(product);
            await this.DbContext.SaveChangesAsync();

            return product.Id;
        }

        public async Task<ProductEditBindingModel> PrepareProductForEditingAsync(int productId, string slug)
        {
            var product = await this.DbContext.Products.FindAsync(productId);
            if (product == null || product.Slug != slug)
            {
                throw new NotFoundException();
            }
            var model = this.Mapper.Map<ProductEditBindingModel>(product);
            return model;
        }

        public async Task<ProductCreationBindingModel> PrepareProductForCreationAsync(int categoryId)
        {
            var category = await this.DbContext.Categories.FindAsync(categoryId);
            if (category == null)
            {
                throw new NotFoundException();
            }
            var model = new ProductCreationBindingModel()
            {
                CategoryId = category.Id
            };

            return model;
        }

        public async Task<ProductRemoveViewModel> PrepareProductForRemoving(int? id, string slug)
        {
            var product = await this.DbContext.Products.FindAsync(id);
            if (product == null || product.Slug != slug)
            {
                throw new NotFoundException();
            }
            var model = this.Mapper.Map<ProductRemoveViewModel>(product);
            return model;
        }

        public async Task<ProductDetailsViewModel> ProductDetailsAsync(int productId, string slug)
        {
            var product = await this.DbContext.Products.FindAsync(productId);
            if (product == null || product.Slug != slug)
            {
                throw new NotFoundException();
            }
            var model = this.Mapper.Map<ProductDetailsViewModel>(product);
            return model;
        }

        public async Task<Category> RemoveProductAsync(int id)
        {
            var product = await this.DbContext.Products.FindAsync(id);
            if(product == null)
            {
                throw new NotFoundException();
            }
            this.DbContext.Remove(product);
            await this.DbContext.SaveChangesAsync();
            var category = DbContext.Categories.Find(product.CategoryId);
            return category;
        }

        public async Task EditProductAsync(int productId, ProductEditBindingModel model)
        {

            Validator.EnsureStringIsNotNullOrEmpty(model.Description, ValidationConstants.ProductDescriptionMessage);
            Validator.EnsureDoubleIsNotNegativeOrZero(model.Price, ValidationConstants.ProductPriceMessage);

            var product = await this.DbContext.Products.FindAsync(productId);
            if(product == null)
            {
                throw new NotFoundException();
            }

            product.Description = model.Description;
            product.Price = model.Price;
            product.ProductImageUrl = model.ProductImageUrl;

            await this.DbContext.SaveChangesAsync();
        }
    }
}
