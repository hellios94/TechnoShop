using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Technoshop.Common.Admin.BindingModels;
using Technoshop.Common.Admin.ViewModels;
using Technoshop.Common.Buyer.ViewModels;
using Technoshop.Data;
using Technoshop.Models;
using Technoshop.Services.Exceptions;
using Technoshop.Services.Moderator.Interfaces;

namespace Technoshop.Services.Moderator
{
    public class ModeratorProductsService : BaseEFService, IModeratorProductsService
    {
        private readonly UserManager<User> userManager;

        public ModeratorProductsService(TechnoshopContext dbContext, IMapper mapper, UserManager<User> userManager)
            : base(dbContext, mapper)
        {
            this.userManager = userManager;
        }

        public async Task<int> CreateProductAsync(ProductCreationBindingModel model, ClaimsPrincipal user)
        {
            var userFromDb = this.userManager.GetUserAsync(user);
            if (user.IsInRole("Moderator") || user.IsInRole("Administrator"))
            {
                var product = this.Mapper.Map<Product>(model);
                await this.DbContext.Products.AddAsync(product);
                await this.DbContext.SaveChangesAsync();

                return product.Id;
            }
            else
            {
                throw new UnauthorizedAccessException();
            }
        }

        public async Task EditProductAsync(int productId, ProductEditBindingModel model, ClaimsPrincipal user)
        {
            var userFromDb = this.userManager.GetUserAsync(user);
            if (user.IsInRole("Moderator") || user.IsInRole("Administrator"))
            {
                var product = await this.DbContext.Products.FindAsync(productId);
                if (product == null)
                {
                    throw new NotFoundException();
                }

                product.Description = model.Description;
                product.Price = model.Price;
                product.ProductImageUrl = model.ProductImageUrl;

                await this.DbContext.SaveChangesAsync();
            }
            else
            {
                throw new UnauthorizedAccessException();
            }
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

        public async Task<Category> RemoveProductAsync(int id, ClaimsPrincipal user)
        {
            var userFromDb = this.userManager.GetUserAsync(user);
            if (user.IsInRole("Moderator") || user.IsInRole("Administrator"))
            {
                var product = await this.DbContext.Products.FindAsync(id);
                if (product == null)
                {
                    throw new NotFoundException();
                }
                this.DbContext.Remove(product);
                await this.DbContext.SaveChangesAsync();
                var category = await this.DbContext.Categories.FindAsync(product.CategoryId);
                return category;
            }
            else
            {
                throw new UnauthorizedAccessException();
            }
        }
    }
}
