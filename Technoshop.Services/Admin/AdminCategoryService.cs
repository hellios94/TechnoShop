using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
    public class AdminCategoryService : BaseEFService, IAdminCategoryService
    {

        public AdminCategoryService(TechnoshopContext dbContext, IMapper mapper)
            :base(dbContext, mapper)
        {
        }

        public async Task<int> AddCategoryAsync(CategoryCreationBindingModel model)
        {
            Validator.EnsureNotNull(model, ValidationConstants.CategoryIsDefinedMessage);
            Validator.EnsureStringIsNotNullOrEmpty(model.Name, ValidationConstants.CategoryNameMessage);
            Validator.EnsureStringIsNotNullOrEmpty(model.Slug, ValidationConstants.CategorySlugMessage);

            var category = this.Mapper.Map<Category>(model);
            await this.DbContext.Categories.AddAsync(category);
            await this.DbContext.SaveChangesAsync();

            return category.Id;
        }

        public async Task<IEnumerable<CategoryConciseViewModel>> GetCategoriesAsync()
        {
            var categories = await this.DbContext.Categories.ToListAsync();
            var modelCategories = this.Mapper.Map<IEnumerable<CategoryConciseViewModel>>(categories);
            return modelCategories;
        }

        public async Task<CategoryDetailsViewModel> GetCategoryDetailsAsync(int id, string slug)
        {
            var categories = await this.DbContext.Categories
                .Include(c => c.Products)
                .FirstOrDefaultAsync(c => c.Id == id);
            if (categories == null || categories.Slug != slug)
            {
                throw new NotFoundException();
            }
            var model = this.Mapper.Map<CategoryDetailsViewModel>(categories);
            return model;
        }

        public async Task<Category> GetCategoryAsync(int id)
        {
            var category = await this.DbContext.Categories.FindAsync(id);
            if (category == null)
            {
                throw new NotFoundException();
            }
            return category;
        }
    }
}
