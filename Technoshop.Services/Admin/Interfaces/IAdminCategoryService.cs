using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Technoshop.Common.Admin.BindingModels;
using Technoshop.Common.Buyer.ViewModels;
using Technoshop.Models;

namespace Technoshop.Services.Admin.Interfaces
{
    public interface IAdminCategoryService
    {

        Task<IEnumerable<CategoryConciseViewModel>> GetCategoriesAsync();

        Task<int> AddCategoryAsync(CategoryCreationBindingModel model);

        Task<CategoryDetailsViewModel> GetCategoryDetailsAsync(int id, string slug);

        Task<Category> GetCategoryAsync(int id);

    }
}
