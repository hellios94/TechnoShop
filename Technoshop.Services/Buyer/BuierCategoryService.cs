using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technoshop.Common.Buyer.ViewModels;
using Technoshop.Data;
using Technoshop.Models;
using Technoshop.Services.Buyer.Interface;
using Technoshop.Services.Exceptions;

namespace Technoshop.Services.Buyer
{
    public class BuyerCategoryService : BaseEFService, IBuyerCategoryService
    {

        public BuyerCategoryService(TechnoshopContext dbContext, IMapper mapper)
            :base(dbContext, mapper)
        {

        }

        public async Task<IEnumerable<CategoryConciseViewModel>> GetCategoriesAsync()
        {
            var categories = await this.DbContext.Categories.ToListAsync();
            var modelCategories = this.Mapper.Map<IEnumerable<CategoryConciseViewModel>>(categories);
            return modelCategories;
        }

        public async Task<CategoryDetailsViewModel> GetCategoryDetailsAsync(int id, string slug)
        {
            var category = await this.DbContext.Categories
                .Include(c => c.Products)
                .FirstOrDefaultAsync(c => c.Id == id);
            if (category == null || category.Slug != slug)
            {
                throw new NotFoundException();
            }
            var model = this.Mapper.Map<CategoryDetailsViewModel>(category);
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
